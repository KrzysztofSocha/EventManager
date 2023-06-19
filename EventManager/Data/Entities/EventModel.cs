using System.ComponentModel.DataAnnotations;
using EventManager.Data.Entities.EntityBase;

namespace EventManager.Data.Entities
{
    public class EventModel : IHasCreationAudited
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Description { get; set; }

        public bool IsAnonymous { get; set; }

        public int? PeopleLimit { get; set; }
        [Required]
        public bool IsLimitReached { get; set; }
        public DateTime CreationTime { get; set; }
        public string? CreatorUserId { get; set; }
        public ICollection<EventUserModel> Observers { get;}
        public ICollection<NotificationModel> Notifications { get;}
        public EventModel()
        {
            Observers = new List<EventUserModel>();
            Notifications = new List<NotificationModel>();
        }

       
    }
}
