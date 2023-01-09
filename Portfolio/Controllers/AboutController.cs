using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using Entities;
using FluentValidation.Results;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        [AllowAnonymous]
        public IActionResult About()
        {
           var values= _aboutManager.GetAll();
            return View(values);
        }


        public IActionResult AdminGetAllAbout()
        {
            var values = _aboutManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AdminAboutAdd()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult AdminAboutAdd(AboutModel aboutModel)
        {
            About about = new About();
            if (aboutModel.ImagePath != null)
            {
                var extension = Path.GetExtension(aboutModel.ImagePath.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                aboutModel.ImagePath.CopyTo(stream);
                about.ImagePath = newImageName;
                about.MyAboutDescription = aboutModel.MyAboutDescription;
                about.Title = aboutModel.Title;

                _aboutManager.Add(about);
                return RedirectToAction("AdminGetAllAbout", "About");
            }

            return View();
        }

        public IActionResult AdminAboutDelete(int id)
        {
            var about = _aboutManager.GetById(id);
            _aboutManager.Delete(about);
            if (System.IO.File.Exists(about.ImagePath))
            {
                System.IO.File.Delete(about.ImagePath);
                return RedirectToAction("AdminGetAllAbout", "About");
            }

            return RedirectToAction("AdminGetAllAbout", "About");


        }

        [HttpGet]
        public IActionResult AdminAboutUpdate(int id)
        {
            var about = _aboutManager.GetById(id);
            return View(about);
        }

        [HttpPost]
        public IActionResult AdminAboutUpdate(AboutModel aboutModel)
        {

            About about = new About();
            if (aboutModel.ImagePath != null)
            {
                
                var extension = Path.GetExtension(aboutModel.ImagePath.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                
                aboutModel.ImagePath.CopyTo(stream);
                
                about.ImagePath = newImageName;
                about.MyAboutDescription = aboutModel.MyAboutDescription;

                _aboutManager.Update(about);
                return RedirectToAction("AdminGetAllAbout", "About");
            }
            return View();


        }
    }
}
