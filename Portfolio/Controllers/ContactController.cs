using Business.Concrate;
using DataAccess.Concrete;
using Entities;
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
            return RedirectToAction("AdminGetContact","Contact");
        }

        public IActionResult AdminGetByIdContact(int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            var email= contact.Email;
            var message= contact.Message;

             contactManager.Add(contact);
            if (Ok().StatusCode==200)
            {
                return RedirectToAction("Add");
            }
            return BadRequest();
            
           
        }
    }
}
