namespace EventManager.Models.Notification
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string SharingTime { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public bool IsRead { get; set; }
    }
}
