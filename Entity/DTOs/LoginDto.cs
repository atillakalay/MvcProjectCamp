using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class LoginDto
    {
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminRole { get; set; }
    }
}
