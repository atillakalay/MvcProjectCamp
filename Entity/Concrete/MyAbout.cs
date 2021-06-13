using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class MyAbout
    {
        [Key]
        public int SkillId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string AboutShort { get; set; }
        [StringLength(100)]
        public string ImagePath { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Skill1 { get; set; }
        [StringLength(100)]
        public string Skill2 { get; set; }
        [StringLength(100)]
        public string Skill3 { get; set; }
        [StringLength(100)]
        public string Skill4 { get; set; }
        public int Rate1 { get; set; }
        public int Rate2 { get; set; }
        public int Rate3 { get; set; }
        public int Rate4 { get; set; }
    }
}
