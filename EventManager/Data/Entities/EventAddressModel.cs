using EventManager.Data.Entities.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Data.Entities
{
    public class EventAddressModel : IEntity
    {
        public int Id { get ; set ; }
        [Required]
        public string City { get; set; }
        [MaxLength(25)]
        public string Address { get; set; }
        public string DescriptionPlace { get; set; }
        public int EventId { get; set; }
        public EventModel Event { get; set; }
    }
}
