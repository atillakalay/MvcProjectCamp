using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        List<T> List();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
