using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> List();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        List<Category> List(Expression<Func<Category, bool>> filter);
    }
}
