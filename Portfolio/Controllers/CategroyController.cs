using Business.Concrate;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class CategroyController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        PortfolioContext portfolioContext = new PortfolioContext();
        public IActionResult Index()
        {
            var values = categoryManager.GetAll();

            return View(values);
        }

        public PartialViewResult GetCategory()
        {
            return PartialView();
        }

    
    }
}
