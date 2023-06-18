namespace EventManager.Models.Observer
{
    public interface IObservable
    {
        public IEnumerable<IObserver> Observers { get; set; }
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        Task SendNotify();

    }
}
