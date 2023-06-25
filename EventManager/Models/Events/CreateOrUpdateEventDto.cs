using AutoMapper;
using EventManager.Data.Entities;

namespace EventManager.Models.Events
{
    [AutoMap(typeof(EventModel))]
    public class CreateOrUpdateEventDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Description { get; set; }
        
       
        public bool IsAnonymous { get; set; }
        public EventAddressDto Address { get; set; }
        
        public CreateOrUpdateEventDto()
        {
            Address = new EventAddressDto();
        }

    }
    
}
