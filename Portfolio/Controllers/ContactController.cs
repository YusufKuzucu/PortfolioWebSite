using Business.Concrate;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        public IActionResult AdminGetContact()
        {
            var values = contactManager.GetAll();
            return View(values);
        }

        public IActionResult AdminDeleteContact(int id)
        {
            var contactValue = contactManager.GetById(id);
            contactManager.Delete(contactValue);
            return RedirectToAction("AdminGetContact", "Contact");
        }

        public IActionResult AdminGetByIdContact(int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            

            ContactValidator contactValidator = new ContactValidator();
            ValidationResult result = contactValidator.Validate(contact);

            if (result.IsValid)
            {
                contactManager.Add(contact);

                return RedirectToAction("Add");
                
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
