using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class ImageManager : IImagerService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Add(Image Image)
        {
            _imageDal.Add(Image);
        }

        public void Delete(Image Image)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetAll()
        {
            throw new NotImplementedException();
        }

        public Image GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetListCategory()
        {
            return _imageDal.GetListCategory();
        }

        public void Update(Image ımage, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
