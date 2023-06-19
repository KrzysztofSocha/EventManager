namespace EventManager.Models.Observer
{
    public interface IObservable<T> where T :class, IObserver
    {
        public ICollection<T> Observers { get;  }
        void Attach(T observer);
        void Detach(T observer);
        void SendNotify(string value);

    }
}
