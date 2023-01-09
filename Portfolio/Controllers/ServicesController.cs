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
    public class ServicesController : Controller
    {
        MyServiceManager _myServiceManager = new MyServiceManager(new EfMyServiceDal());

        [AllowAnonymous]
        public IActionResult Services()
        {
            var values = _myServiceManager.GetAll();
            return View(values);
        }

        public IActionResult AdminGetAllService()
        {
            var values = _myServiceManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AdminServiceAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminServiceAdd(MyService myService)
        {
            MyServiceValidator serviceValidator = new MyServiceValidator();
            ValidationResult result = serviceValidator.Validate(myService);

            if (result.IsValid)
            {
                _myServiceManager.Add(myService);
                return RedirectToAction("AdminGetAllService", "Services");
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

        public IActionResult AdminServiceDelete(int id)
        {
            var service = _myServiceManager.GetById(id);
            _myServiceManager.Delete(service);
            return RedirectToAction("AdminGetAllService", "Services");
        }

        [HttpGet]
        public IActionResult AdminServiceUpdate(int id)
        {
            var about = _myServiceManager.GetById(id);
            return View(about);
        }

        [HttpPost]
        public IActionResult AdminServiceUpdate(MyService myService)
        {

            MyServiceValidator serviceValidator = new MyServiceValidator();
            ValidationResult result = serviceValidator.Validate(myService);

            if (result.IsValid)
            {
                _myServiceManager.Update(myService);
                return RedirectToAction("AdminGetAllService", "Services");
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
