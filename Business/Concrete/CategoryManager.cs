using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager
    {
        private GenericRepository<Category> _genericRepository = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
          return _genericRepository.List();
        }

        public void Add(Category category)
        {
            _genericRepository.Add(category);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
