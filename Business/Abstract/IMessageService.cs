using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string userEmail);
        List<Message> GetListSendbox(string userEmail);
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        List<Message> GetAll(Expression<Func<Message, bool>> filter);
    }
}
