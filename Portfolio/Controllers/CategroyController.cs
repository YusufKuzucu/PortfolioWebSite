using Business.Concrate;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class CategroyController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
       
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if (result.IsValid)
            {
                categoryManager.Update(category);
                return RedirectToAction("AdminGetAllCategory", "Categroy");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

            
        }

    }
}
