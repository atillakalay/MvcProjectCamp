using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAll();
        void Add(About about);
        void Update(About about);
        void Delete(About about);
        List<Category> GetAll(Expression<Func<Category, bool>> filter);
    }
}
