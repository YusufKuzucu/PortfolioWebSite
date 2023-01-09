using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.ViewComponents.FooterImage
{
    public class FooterImage : ViewComponent
    {
        FooterImageManager _footerImage = new FooterImageManager(new EfFooterImageDal());
        public IViewComponentResult Invoke()
        {

            var values = _footerImage.GetAll();

            return View(values);
        }
    }
}
