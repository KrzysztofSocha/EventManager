using EventManager.Data.Entities.EntityBase;

namespace EventManager.Models.Observer
{
    public interface IObserver:IHasCreationTime
    {
        public string ObserverId { get; set; }
    }
}
