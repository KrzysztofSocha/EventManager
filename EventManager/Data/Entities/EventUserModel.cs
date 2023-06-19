using EventManager.Data.Entities.EntityBase;
using EventManager.Models.Observer;
using Microsoft.AspNetCore.Identity;

namespace EventManager.Data.Entities
{
    public class EventUserModel : IObserver
    {
        public string ObserverId { get; set; }
        public IdentityUser Observer { get; set; }
        public int EventId { get; set; }
        public EventModel Event { get; set; }
        public DateTime CreationTime { get; set; }
        public EventUserModel(string observerId)
        {
            ObserverId = observerId;
        }
    }
}
