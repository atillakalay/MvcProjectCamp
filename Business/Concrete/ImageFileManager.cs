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
    public class ImageFileManager : IImageFileService
    {
        private IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public List<ImageFile> GetAll()
        {
            return _imageFileDal.List();
        }
        public void Add(ImageFile imageFile)
        {
            _imageFileDal.Add(imageFile);
        }
    }
}
