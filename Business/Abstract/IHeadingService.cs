using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetAll();
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);
        List<Category> GetAll(Expression<Func<Category, bool>> filter);
    }
}
