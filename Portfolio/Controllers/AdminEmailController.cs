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
    public class AdminEmailController : Controller
    {
        AdminEmailManager _adminEmailManager = new AdminEmailManager(new EfAdminEmailDal());
        public IActionResult Index()
        {
            var values = _adminEmailManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminEmail adminEmail)
        {

            AdminEmailValidator emailValidator = new AdminEmailValidator();
            ValidationResult result = emailValidator.Validate(adminEmail);

            if (result.IsValid)
            {
                _adminEmailManager.Add(adminEmail);
                return RedirectToAction("Index", "AdminEmail");
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

        public IActionResult AdminDeleteEmail(int id)
        {
            var email = _adminEmailManager.GetById(id);
            _adminEmailManager.Delete(email);
            return RedirectToAction("Index", "AdminEmail");
        }

        [HttpGet]
        public IActionResult AdminUpdateEmail(int id)
        {
            var email = _adminEmailManager.GetById(id);
            return View(email);
        }

        [HttpPost]
        public IActionResult AdminUpdateEmail(AdminEmail adminEmail)
        {

            AdminEmailValidator emailValidator = new AdminEmailValidator();
            ValidationResult result = emailValidator.Validate(adminEmail);

            if (result.IsValid)
            {
                _adminEmailManager.Update(adminEmail);
                return RedirectToAction("Index", "AdminEmail");
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
