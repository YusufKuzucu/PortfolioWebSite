using Business.Concrate;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public IActionResult AdminGetAllCategory()
        {
            var values = categoryManager.GetAll();
            return View(values);
        }

        public IActionResult AdminDeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            categoryManager.Delete(categoryValue);
            return RedirectToAction("AdminGetAllCategory", "Categroy");

        }

        [HttpGet]
        public IActionResult AdminCategoryUpdate(int id)
        {
            var categoryValues = categoryManager.GetById(id);
            return View(categoryValues);
        }

        [HttpPost]
        public IActionResult AdminCategoryUpdate(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("AdminGetAllCategory", "Categroy");
        }

    }
}
