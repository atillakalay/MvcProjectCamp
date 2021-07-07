using System.ComponentModel.DataAnnotations;
using Core.Entity;

namespace Entity.Concrete
{
    public class Ability:IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string AbilityName { get; set; }

        public int KnowledgeLevel { get; set; }
    }
}
