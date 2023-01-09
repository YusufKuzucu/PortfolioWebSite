using Business.Concrate;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Portfolio.ViewComponents.Image
{
    public class ImageList : ViewComponent
    {
        ImageManager imgManager = new ImageManager(new EfImageDal());
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
          
            var values = imgManager.GetAll();
            
            return View(values);
        }
    }
}
