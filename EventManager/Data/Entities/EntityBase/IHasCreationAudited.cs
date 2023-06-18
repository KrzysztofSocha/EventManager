using System.ComponentModel.DataAnnotations;

namespace EventManager.Data.Entities.EntityBase
{
    public interface IHasCreationAudited
    {
       
        public DateTime CreationTime { get; set; }
        [MaxLength(450)]
        public string? CreatorUserId { get; set; }

    }
}
