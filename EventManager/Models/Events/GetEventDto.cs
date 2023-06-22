using AutoMapper;
using EventManager.Data.Entities;

namespace EventManager.Models.Events
{
    //[AutoMap(typeof(EventModel))]
    public class GetEventDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Description { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }

        public string SharingTime { get; set; }

        public EventAddressDto Address { get; set; }
        public bool IsAnonymous { get; set; }

        public string Author { get; set; }

        public List<GetSubscriberDto> Observers { get; set; }
        public List<EventMessagesDto> Notifications { get; set; }
    }
    //[AutoMap(typeof(EventUserModel))]
    public class GetSubscriberDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }

    }
    //[AutoMap(typeof(NotificationModel))]
    public class EventMessagesDto
    {
        public int Id { get; set; }
        public string SharingTime { get; set; }

        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
    [AutoMap(typeof(EventAddressModel))]
    public class EventAddressDto
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string DescriptionPlace { get; set; }
    }
}
