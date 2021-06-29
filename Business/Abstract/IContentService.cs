using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetSearchedWords(string searchedWords);
        List<Content> GetAllByWriter();
        List<Content> GetListById(int id);
        List<Content> GetListByWriter(int id);

        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);

    }
}
