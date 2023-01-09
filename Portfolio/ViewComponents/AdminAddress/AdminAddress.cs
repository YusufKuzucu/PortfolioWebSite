using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.AdminAddress
{
    public class AdminAddress : ViewComponent
    {
        AdminAddressManager _adminAddress = new AdminAddressManager(new EfAdminAddressDal());

        public IViewComponentResult Invoke()
        {
            var values = _adminAddress.GetAll();

            return View(values);
        }
    }
}
