using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMyAboutDal : GenericRepository<MyAbout>, IMyAboutDal
    {
    }
}
