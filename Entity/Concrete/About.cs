using System.ComponentModel.DataAnnotations;
using Core.Entity;


namespace Entity.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(1000)]
        public string AboutDetails1 { get; set; }
        [StringLength(1000)]
        public string AboutDetails2 { get; set; }
        [StringLength(250)]
        public string AboutImage1 { get; set; }
        [StringLength(250)]
        public string AboutImage2 { get; set; }
    }
}
