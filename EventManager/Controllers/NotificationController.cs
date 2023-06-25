using AutoMapper;
using EventManager.Data.Entities;
using EventManager.Data.Repositories;
using EventManager.Models.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventManager.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserNotificationModel> _userNotificationRepository;
        public NotificationController(IMapper mapper, IRepository<UserNotificationModel> userNotificationRepository)
        {
            _mapper = mapper;
            _userNotificationRepository = userNotificationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notifications = await _userNotificationRepository.GetAll().AsNoTracking()
                .Include(x => x.Notification).ThenInclude(x=>x.Event)
                .Where(x => x.UserId == currentUserId)
                .OrderByDescending(x=>x.Notification.CreationTime)
                .ToListAsync();
            var output = _mapper.Map<List<NotificationViewModel>>(notifications);
            foreach (var notify in notifications.Where(x=>!x.IsRead))
            {
                var tracked = await _userNotificationRepository.GetByIdAsync(notify.Id);
                tracked.IsRead = true;
                await _userNotificationRepository.UpdateAsync(tracked);
            }
            
            return View(output);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notify = await _userNotificationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id && x.UserId == currentUserId);
            if (notify != null)
                await _userNotificationRepository.DeleteAsync(notify);
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Edit(int id)
        {
            return View();
        }

    }
}
