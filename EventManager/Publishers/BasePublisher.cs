
using EventManager.Models.Observer;

namespace EventManager.Publishers
{
    public abstract class BasePublisher<T> : Models.Observer.IObservable<T> where T :class, IObserver
    {
        public ICollection<T> Observers { get; }
        public BasePublisher(ICollection<T> observers)
        {
            Observers = observers;
        }


        public virtual void Attach(T observer)
        {
            if(observer.ObserverId != null)
                Observers.Add(observer);
        }

        public virtual void Detach(T observer)
        {
            if (observer.ObserverId != null)
                Observers.Remove(observer);
        }

        public abstract void SendNotify(string value);
        
    }
}
