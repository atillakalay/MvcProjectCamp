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
            var addEntity = _efContext.Entry(entity);
            addEntity.State = EntityState.Added;
            _efContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            var deleteEntity = _efContext.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
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

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Update(T entity)
        {
            var updateEntity = _efContext.Entry(entity);
            updateEntity.State = EntityState.Modified;
            _efContext.SaveChanges();
        }
    }
}
