using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox(string userEmail)
        {
            return _messageDal.List(x => x.ReceiverMail == userEmail);
        }

        public List<Message> GetListSendbox(string userEmail)
        {
            return _messageDal.List(x => x.SenderMail == userEmail);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.Id == id);
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.List(filter);
        }
    }
}
