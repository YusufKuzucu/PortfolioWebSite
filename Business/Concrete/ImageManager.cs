using Business.Abstract;
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
        public void Add(IFormFile file, int categoryId)
        {
            throw new NotImplementedException();
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

        public void Update(Image ımage, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
