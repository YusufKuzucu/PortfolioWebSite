using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using Entities;
using FluentValidation.Results;
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
    public class FooterImagesController : Controller
    {
        FooterImageManager _footerImage = new FooterImageManager(new EfFooterImageDal());


        public IActionResult AdminFooterImageGetAll()
        {
            var values = _footerImage.GetAll();
            return View(values);
        }

        
        [HttpGet]
        public IActionResult AdminFooterImageAdd()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AdminFooterImageAdd(FooterModel footerModel)
        {
            FooterImage footerImage = new FooterImage();
            if (footerModel.ImagePath != null)
            {
                var extension = Path.GetExtension(footerModel.ImagePath.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                footerModel.ImagePath.CopyTo(stream);
                footerImage.ImagePath = newImageName;
                footerImage.Date = DateTime.Now;
                

                _footerImage.Add(footerImage);
                return RedirectToAction("AdminFooterImageGetAll", "FooterImages");
            }

            return View();
        }

        public IActionResult AdminFooterImageDelete(int id)
        {
            var footerImage = _footerImage.GetById(id);
            _footerImage.Delete(footerImage);
            if (System.IO.File.Exists(footerImage.ImagePath))
            {
                System.IO.File.Delete(footerImage.ImagePath);
                return RedirectToAction("AdminFooterImageGetAll", "FooterImages");
            }
           
            return RedirectToAction("AdminFooterImageGetAll", "FooterImages");
        }

        [HttpGet]
        public IActionResult AdminFooterImageUpdate(int id)
        {
            var footerImage = _footerImage.GetById(id);
            return View(footerImage);
        }

        [HttpPost]
        public IActionResult AdminFooterImageUpdate(FooterModel footerModel)
        {
            FooterImage footerImage = new FooterImage();
            if (footerModel.ImagePath != null)
            {
                var extension = Path.GetExtension(footerModel.ImagePath.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                footerModel.ImagePath.CopyTo(stream);
                footerImage.ImagePath = newImageName;
                footerImage.Date = DateTime.Now;


                _footerImage.Add(footerImage);
                return RedirectToAction("AdminFooterImageGetAll", "FooterImages");
            }

            return View();
        }
    }
}
