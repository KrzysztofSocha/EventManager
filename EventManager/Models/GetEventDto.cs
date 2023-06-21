namespace EventManager.Models
{
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
       
       //public EventAddressDto Address { get; set; }
        public bool IsAnonymous { get; set; }
      
        public string Author { get; set; }
        
        public List<GetSubscriberDto> Observers { get; set; }
        public List<EventMessagesDto> Notifications { get; set; }
    }
    public class GetSubscriberDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        
    }
    public class EventMessagesDto
    {
        public int Id { get; set; }
        public string SharingTime { get; set; }
       
        public string Message { get; set; }
    }
}
