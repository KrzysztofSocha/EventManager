using EventManager.Data.Entities.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Data.Entities
{
    public class NotificationModel: IEntity, IHasCreationTime   
    {
        public int Id { get; set; }
        public DateTime CreationTime { get ; set ; }
        [MaxLength(250)]
        public string Message { get; set; }
        public int EventId { get; set; }
        public EventModel Event { get; set; }
        public ICollection<UserNotificationModel> UserNotifications { get; set; }
        public NotificationModel(string message)
        {
            UserNotifications = new List<UserNotificationModel>();
            Message = message;
        }
        public NotificationModel()
        {
            UserNotifications = new List<UserNotificationModel>();
        }
    }
}
