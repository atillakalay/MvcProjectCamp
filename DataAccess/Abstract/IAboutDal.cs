using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IAboutDal : IEntityRepository<About>
    {
    }
}

