using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EventManager.Data.Entities.EntityBase;

namespace EventManager.Data.Entities
{
    
    public class EventModel : IHasCreationAudited, IHasModificationAudited
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Description { get; set; }

        public bool IsAnonymous { get; set; }

        
        
        public DateTime CreationTime { get; set; }
        public string? CreatorUserId { get; set; }
        public ICollection<EventUserModel> Observers { get;}
        public ICollection<NotificationModel> Notifications { get;}
        public EventAddressModel Address { get; set; }
        public DateTime? ModificationTime { get ; set ; }
        public string? ModificationUser { get; set; }

        public EventModel()
        {
            Observers = new List<EventUserModel>();
            Notifications = new List<NotificationModel>();
        }

       
    }
}
