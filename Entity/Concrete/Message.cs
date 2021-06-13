using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool isDraft { get; set; }
        public bool IsRead { get; set; }
    }
}
