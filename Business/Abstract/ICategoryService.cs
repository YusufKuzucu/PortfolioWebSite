using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category Category);
        void Delete(Category Category);
        void Update(Category Category);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
