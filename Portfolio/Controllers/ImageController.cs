using Business.Concrate;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class ImageController : Controller
    {
        ImageManager _imageManager = new ImageManager(new EfImageDal());

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminGetAllImage()
        {
            var values = _imageManager.GetListCategory();
            return View(values);
        }

        public IActionResult AdminDeleteImage(int id)
        {
            var imageValue = _imageManager.GetById(id);
            _imageManager.Delete(imageValue);
            if (System.IO.File.Exists(imageValue.ImagePath))
            {
                System.IO.File.Delete(imageValue.ImagePath);
                return RedirectToAction("AdminGetAllImage", "Image");
            }
            return RedirectToAction("AdminGetAllImage", "Image");

        }


    }
}
