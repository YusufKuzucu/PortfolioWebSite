using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class AdminAddressController : Controller
    {
        AdminAddressManager _adminAddressManager = new AdminAddressManager(new EfAdminAddressDal());
        public IActionResult Index()
        {
            var values = _adminAddressManager.GetAll();
            return View(values);
        }

        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Add(AdminAddress adminAddress)
        {
            AdminAddressValidator addressValidator = new AdminAddressValidator();
            ValidationResult result = addressValidator.Validate(adminAddress);

            if (result.IsValid)
            {
                _adminAddressManager.Add(adminAddress);
                return RedirectToAction("Index", "AdminAddress");
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

        public IActionResult AdminDeleteAddress(int id)
        {
            var address = _adminAddressManager.GetById(id);
            _adminAddressManager.Delete(address);
            return RedirectToAction("Index", "AdminAddress");
        }

        [HttpGet]
        public IActionResult AdminUpdateAddress(int id)
        {
            var adress = _adminAddressManager.GetById(id);
            return View(adress);
        }

        [HttpPost]
        public IActionResult AdminUpdateAddress(AdminAddress adminAddress)
        {
            AdminAddressValidator addressValidator = new AdminAddressValidator();
            ValidationResult result = addressValidator.Validate(adminAddress);

            if (result.IsValid)
            {
                _adminAddressManager.Update(adminAddress);
                return RedirectToAction("Index", "AdminAddress");
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
