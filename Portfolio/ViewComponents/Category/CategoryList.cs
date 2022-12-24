using Business.Concrate;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetAll();

            return View(values);
        }
    }
}
