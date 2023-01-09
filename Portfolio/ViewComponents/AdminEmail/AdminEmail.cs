using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.AdminEmail
{
    public class AdminEmail : ViewComponent
    {
        AdminEmailManager _adminEmail = new AdminEmailManager(new EfAdminEmailDal());

        public IViewComponentResult Invoke()
        {
            var values = _adminEmail.GetAll();

            return View(values);
        }
    }
}
