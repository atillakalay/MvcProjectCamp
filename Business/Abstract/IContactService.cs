using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
