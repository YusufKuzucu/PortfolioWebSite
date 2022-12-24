using Business.Concrate;
using DataAccess.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioPresentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class AdminHomeController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ImageManager imageManager = new ImageManager(new EfImageDal());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            categoryManager.Add(category);
            return RedirectToAction("Index","AdminHome");

        }



        [HttpGet]
        public IActionResult ImageAdd()
        {
            GettCategoryListItem();
            return View();
        }


        [HttpPost]
        public IActionResult ImageAdd(AddImage image)
        {
            Image imageSite = new Image();
            if (image.ImagePath!=null)
            {
                var extension = Path.GetExtension(image.ImagePath.FileName);
                var newImageName = Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/",newImageName);
                var stream = new FileStream(location , FileMode.Create);
                image.ImagePath.CopyTo(stream);
                imageSite.ImagePath = newImageName;
            }

            imageManager.Add(imageSite);
            return View();
        }



        public void GettCategoryListItem()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryValues = (from x in cm.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.CategoryList = categoryValues;

        }
    }
}
