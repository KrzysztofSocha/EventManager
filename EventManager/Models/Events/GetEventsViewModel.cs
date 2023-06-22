namespace EventManager.Models.Events
{
    public class GetEventsViewModel
    {
        public List<GetEventDto> Events { get; set; }
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
