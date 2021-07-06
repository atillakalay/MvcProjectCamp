
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
