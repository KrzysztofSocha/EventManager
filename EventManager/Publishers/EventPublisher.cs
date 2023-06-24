using EventManager.Data.Entities;
using System.Security.Claims;

namespace EventManager.Publishers
{
    public class EventPublisher : BasePublisher<EventUserModel>
    {
        //public ICollection<EventUserModel> Observers /*= new List<EventUserModel>()*/;
        private EventModel _event;

        //private readonly IHttpContextAccessor _httpContextAccessor;
        //public EventPublisher( IHttpContextAccessor httpContextAccessor ) 
        //{

        //    _httpContextAccessor = httpContextAccessor;

        //}
        public EventPublisher(EventModel @event):base(@event.Observers)
        {
            _event = @event;
            //Observers =base.Observers;
        }
        //public void SetCurrentEvent(EventModel @event)
        //{
        //    _event = @event;
        //    Observers = @event.Observers;
            
        //}

        public override void Attach(EventUserModel observer)
        {
            if (_event.CreatorUserId != observer.ObserverId && Observers.All(x => x.ObserverId != observer.ObserverId))
                base.Attach(observer);
        }

        public override void Detach(EventUserModel observer)
        {
            //var sub = Observers.FirstOrDefault(x => x.ObserverId == observer.ObserverId);
            if (Observers.Any(x=>x.ObserverId==observer.ObserverId))
            {
                base.Detach(observer);
            }
           

        }

        public override void SendNotify(string value)
        {
            var notify =new NotificationModel(value);
            foreach (var subs in Observers)
            {
                notify.UserNotifications.Add(new UserNotificationModel { UserId = subs.ObserverId });
            }
            _event.Notifications.Add(notify);
        }
    }
}
