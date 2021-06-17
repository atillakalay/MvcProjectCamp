using System.Collections.Generic;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        Heading GetById(int id);
        List<Heading> GetAll();
        List<Heading> GetListByWriter(int id);
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);

    }
}
