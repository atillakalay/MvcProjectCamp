using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> List(Expression<Func<T, bool>> filter);
        List<T> List();
        T Get(Expression<Func<T, bool>> filter);
    }
}
