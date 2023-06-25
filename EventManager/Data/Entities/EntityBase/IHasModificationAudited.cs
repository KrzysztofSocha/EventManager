namespace EventManager.Data.Entities.EntityBase
{
    public interface IHasModificationAudited:IEntity
    {
        public DateTime? ModificationTime { get; set; }
        public string? ModificationUser { get; set; }
    }
}
