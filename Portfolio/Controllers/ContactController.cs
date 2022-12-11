using Business.Concrate;
using DataAccess.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        public IActionResult Index()
        {
            var values = contactManager.GetAll();
            return View(values);
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
