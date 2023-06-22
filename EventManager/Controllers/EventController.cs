using EventManager.Data.Entities;
using EventManager.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq;
using AutoMapper;
using EventManager.Models.Events;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using EventManager.Publishers;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly IRepository<EventModel> _eventRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public EventController(IRepository<EventModel> eventRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string city, DateTime? startDate)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = await _userManager.FindByIdAsync(currentUserId);
            if (startDate == null)
                city = "Rzeszów";
            if (startDate.HasValue && startDate.Value.Date == DateTime.Now.Date)
                startDate = null;
            var avaialableEvents = _eventRepository.GetAll().Include(x => x.Address)
                .Where(x => x.StartTime >= DateTime.Now || (x.FinishTime.HasValue && x.FinishTime.Value >= DateTime.Now));
            if (!string.IsNullOrEmpty(city))
                avaialableEvents = avaialableEvents.Where(x => x.Address.City.Contains(city));
            if (startDate.HasValue)
                avaialableEvents = avaialableEvents.Where(x => x.StartTime.Date == startDate.Value.Date);

            var result = await avaialableEvents.OrderBy(x => x.StartTime).ToListAsync();
            var output = _mapper.Map<List<GetEventDto>>(result);
            foreach (var item in output)
            {
                if (!item.IsAnonymous)
                {
                    var user = await _userManager.FindByIdAsync(item.CreatorUserId);
                    item.Author = user.UserName;
                }

            }
            var model = new GetEventsViewModel()
            {
                Events = output,
                City = city,
                StartDate = startDate,
                CurrentUserId=currentUserId
            };
            return View(model);
        }
        public async Task<IActionResult> EventDetails(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = _eventRepository.GetAll().Include(x => x.Address)
                .Include(x => x.Notifications).Where(x => x.Id == id);

            if (currentUserId == query.First().CreatorUserId)
                query.Include(x => x.Observers).ThenInclude(x => x.Observer);
            var @event = await query.FirstAsync();

            var result = _mapper.Map<GetEventDto>(@event);
            if (!result.IsAnonymous)
            {
                var user = await _userManager.FindByIdAsync(result.CreatorUserId);
                result.Author = user.UserName;
            }
            return View(result);
        }
        public async Task<IActionResult> Subscribe(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var @event = await _eventRepository.GetByIdAsync(id);
            var publisher = new EventPublisher(@event);
            publisher.Attach(new EventUserModel(currentUserId));
            await _eventRepository.UpdateAsync(@event);
            return View();
        }
        public async Task<IActionResult> Unsubscribe(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var @event = await _eventRepository.GetByIdAsync(id);
            var publisher = new EventPublisher(@event);
            publisher.Detach(new EventUserModel(currentUserId));
            await _eventRepository.UpdateAsync(@event);
            return View();
        }
        public async Task<IActionResult> AddNotify(int id, string message)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var @event = await _eventRepository.GetByIdAsync(id);
           
            if(currentUserId == @event.CreatorUserId)
            {
                var publisher = new EventPublisher(@event);
                publisher.SendNotify(message);
                await _eventRepository.UpdateAsync(@event);
            }
            
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var @event = await _eventRepository.GetByIdAsync(id);
            if (currentUserId == @event.CreatorUserId)
            {
                await _eventRepository.DeleteAsync(@event);
            }
            return View();
        }
        public async Task<IActionResult> UserEvents()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result =await  _eventRepository.GetAll()
                .Include(x => x.Address)
                .Where(x => x.CreatorUserId == currentUserId)
                .OrderByDescending(x => x.CreationTime).ToListAsync();
            var output = _mapper.Map<List<GetEventDto>>(result);
            return View(output);
        }
        public async Task<IActionResult> EventAttached()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _eventRepository.GetAll()
                .Include(x => x.Address)
                .Include(x=>x.Observers)
                .Where(x => x.Observers.Any(x=>x.ObserverId==currentUserId))
                .OrderByDescending(x => x.CreationTime).ToListAsync();
            var output = _mapper.Map<List<GetEventDto>>(result);
            output.ForEach(x => x.Observers.Clear());
            return View(output);
        }

    }
}
