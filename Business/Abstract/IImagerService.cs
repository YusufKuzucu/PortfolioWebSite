using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImagerService
    {
        void Add(Image Image);
        void Delete(Image Image);
        void Update(Image ımage, IFormFile file);
        List<Image> GetAll();
        Image GetById(int id);
        List<Image> GetByCategoryId(int categoryId);
        List<Image> GetListCategory();
        List<Image> GetCategoryName(string categoryName);
    }
}
