using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);
        List<Category> GetAll(Expression<Func<Category, bool>> filter);
    }
}
