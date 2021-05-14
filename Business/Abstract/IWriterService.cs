using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);
        Writer GetById(int id);
    }
}
