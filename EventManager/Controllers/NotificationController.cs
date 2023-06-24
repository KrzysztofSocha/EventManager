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
            var notifications = await _userNotificationRepository.GetAll()
                .Include(x => x.Notification).ThenInclude(x=>x.Event).AsNoTracking()
                .Where(x => x.UserId == currentUserId).ToListAsync();
            var output = _mapper.Map<List<NotificationViewModel>>(notifications);
            return View(output);
        }
    }
}
