using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }


        public ICollection<Content> Contents { get; set; }
    }
}