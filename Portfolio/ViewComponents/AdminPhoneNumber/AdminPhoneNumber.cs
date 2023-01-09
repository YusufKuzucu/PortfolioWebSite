using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.AdminPhoneNumber
{
    public class AdminPhoneNumber : ViewComponent
    {
        AdminPhoneNumberManager _adminEmail = new AdminPhoneNumberManager(new EfAdminPhoneNumberDal());

        public IViewComponentResult Invoke()
        {
            var values = _adminEmail.GetAll();

            return View(values);
        }
    }
}
