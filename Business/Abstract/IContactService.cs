using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entity.Concrete;

namespace Business.Abstract
{
 public   interface IContactService
    {
        List<About> GetAll();
        void Add(About about);
        void Update(About about);
        void Delete(About about);
        List<Contact> GetAll(Expression<Func<Contact, bool>> filter);
    }
}
