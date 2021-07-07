using System.Collections.Generic;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetAll();
        void Add(ImageFile imageFile);
    }

}
