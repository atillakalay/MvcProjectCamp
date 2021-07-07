using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }


        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.List();
        }

     

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id && x.HeadingStatus == true);
        }

        public List<Heading> GetAll(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public void Add(Heading heading)
        {
            heading.CreatedDate=DateTime.Now;
            _headingDal.Add(heading);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
