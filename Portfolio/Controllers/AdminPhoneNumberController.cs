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
    public class AdminPhoneNumberController : Controller
    {
        AdminPhoneNumberManager _adminPhoneNumber = new AdminPhoneNumberManager(new EfAdminPhoneNumberDal());
        public IActionResult Index()
        {
            var values = _adminPhoneNumber.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminPhoneNumber adminPhoneNumber)
        {
            AdminPhoneNumberValidator phoneNumberValidator = new AdminPhoneNumberValidator();
            ValidationResult result = phoneNumberValidator.Validate(adminPhoneNumber);

            if (result.IsValid)
            {
                _adminPhoneNumber.Add(adminPhoneNumber);
                return RedirectToAction("Index","AdminPhoneNumber");
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

        public IActionResult AdminDeletePhoneNumber(int id)
        {
            var email = _adminPhoneNumber.GetById(id);
            _adminPhoneNumber.Delete(email);
            return RedirectToAction("Index", "AdminPhoneNumber");
        }

        [HttpGet]
        public IActionResult AdminUpdatePhoneNumber(int id)
        {
            var email = _adminPhoneNumber.GetById(id);
            return View(email);
        }

        [HttpPost]
        public IActionResult AdminUpdatePhoneNumber(AdminPhoneNumber adminPhoneNumber)
        {

            AdminPhoneNumberValidator phoneValidator = new AdminPhoneNumberValidator();
            ValidationResult result = phoneValidator.Validate(adminPhoneNumber);

            if (result.IsValid)
            {
                _adminPhoneNumber.Update(adminPhoneNumber);
                return RedirectToAction("Index", "AdminPhoneNumber");
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
