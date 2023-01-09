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
            _imageDal.Delete(Image);
        }

        public List<Image> GetAll()
        {
            return _imageDal.GetAll();
        }

        public List<Image> GetByCategoryId(int categoryId)
        {
            return _imageDal.GetAll(x => x.CategoryId == categoryId).ToList();
        }

        public Image GetById(int id)
        {
            return _imageDal.GetById(id);
        }

        public List<Image> GetCategoryName(string categoryName)
        {
            return _imageDal.GetAll(x=>x.Category.CategoryName.Contains(categoryName));
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
