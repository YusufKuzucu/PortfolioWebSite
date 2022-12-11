using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImagerService
    {
        void Add(IFormFile file, int categoryId);
        void Delete(Image Image);
        void Update(Image ımage, IFormFile file);
        List<Image> GetAll();
        Image GetById(int id);
    }
}
