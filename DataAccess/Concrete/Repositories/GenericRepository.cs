using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;


namespace DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IEntityRepository<T> where T : class
    {
        EfContext _efContext = new EfContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = _efContext.Set<T>();
        }

        public void Add(T entity)
        {
            _object.Add(entity);
            _efContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            _efContext.SaveChanges();
        }

        public List<T> List()
        {

            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            _efContext.SaveChanges();
        }
    }
}
