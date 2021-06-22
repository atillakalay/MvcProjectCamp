using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
   public interface IWriterLoginService
   {
       Writer GetWriter(string userName,string password);
   }
}
