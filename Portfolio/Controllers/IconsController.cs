using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class IconsController : Controller
    {
        IconManager iconManager = new IconManager(new EfIconDal());
        public IActionResult IconIndex()
        {
            var values = iconManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AdminIconAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminIconAdd(Icon icon)
        {

            IconValidator iconeValidator = new IconValidator();
            ValidationResult result = iconeValidator.Validate(icon);

            if (result.IsValid)
            {
                iconManager.Add(icon);
                return RedirectToAction("IconIndex", "Icons");
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

        public IActionResult AdminIconDelete(int id)
        {
            var icon = iconManager.GetById(id);
            iconManager.Delete(icon);
            return RedirectToAction("IconIndex", "Icons");
        }


        [HttpGet]
        public IActionResult AdminIconUpdate(int id)
        {
            var icon = iconManager.GetById(id);
           
            return View(icon);
        }

        [HttpPost]
        public IActionResult AdminIconUpdate(Icon icon)
        {

            IconValidator iconeValidator = new IconValidator();
            ValidationResult result = iconeValidator.Validate(icon);

            if (result.IsValid)
            {
                iconManager.Update(icon);
                return RedirectToAction("IconIndex", "Icons");
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
