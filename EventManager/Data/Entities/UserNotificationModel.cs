using EventManager.Data.Entities.EntityBase;
using Microsoft.AspNetCore.Identity;

namespace EventManager.Data.Entities
{
    public class UserNotificationModel:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int NotificationId { get; set; }
        public NotificationModel Notification { get; set; }
        
    }
}
