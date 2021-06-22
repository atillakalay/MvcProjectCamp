using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        private IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string userName, string password)
        {
            return _writerDal.Get(x => x.WriterMail == userName && x.WriterPassword == password);
        }
    }
}
