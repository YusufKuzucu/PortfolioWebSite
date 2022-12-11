using Business.Concrate;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioPresentation.Controllers
{
    public class HomePageController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        PortfolioContext portfolioContext = new PortfolioContext();
        public IActionResult Index()
        {
            var values = categoryManager.GetAll();

            return View(values);
        }
    }
}
