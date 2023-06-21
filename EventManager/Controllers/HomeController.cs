using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using EventManager.Data.Repositories;
using EventManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using EventManager.Publishers;

namespace EventManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRepository<EventModel> _eventRepository;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IRepository<EventModel> eventRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var date = DateTime.MinValue;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //await _userManager.GetClaimsAsync();
            var eventa = await _eventRepository.GetAll().Include(x=>x.Observers).Include(x=>x.Notifications).FirstAsync(x=>x.Id==7);
            //if (eventa?.CreatorUserId != userId && userId != null)
            //{
            //   
            //}
            var publisher = new EventPublisher(eventa);
            //    publisher.Attach(new EventUserModel(userId));
            publisher.SendNotify("Test Powiadomienia 2");
            await _eventRepository.UpdateAsync(eventa);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}