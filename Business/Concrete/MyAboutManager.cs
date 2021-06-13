using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class MyAboutManager : IMyAboutService
    {
        private IMyAboutDal _myAboutDal;

        public MyAboutManager(IMyAboutDal myAboutDal)
        {
            _myAboutDal = myAboutDal;
        }

        public List<MyAbout> GetAll()
        {
            return _myAboutDal.List();
        }
    }
}
