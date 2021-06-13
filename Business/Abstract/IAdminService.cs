using System.Collections.Generic;
using Entity.Concrete;


namespace Business.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
