using System.ComponentModel.DataAnnotations;
using Core.Entity;

namespace Entity.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
        public bool AdminStatus { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
