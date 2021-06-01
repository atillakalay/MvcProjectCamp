using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
    }
}
