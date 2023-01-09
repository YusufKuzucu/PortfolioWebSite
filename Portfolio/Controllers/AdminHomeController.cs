using Business.Concrate;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioPresentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{

    public class AdminHomeController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);

            if (result.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("AdminGetAllCategory", "Categroy");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

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
            if (image.ImagePath != null)
            {
                var extension = Path.GetExtension(image.ImagePath.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                image.ImagePath.CopyTo(stream);
                imageSite.ImagePath = newImageName;
                imageSite.Date = DateTime.Now;
                imageSite.CategoryId = image.CategoryId;
            }
            GettCategoryListItem();
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(Admin admin)
        {
            adminManager.Add(admin);
            return RedirectToAction("Index", "AdminHome");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            PortfolioContext context = new PortfolioContext();
            var adminInfo = context.Admins.FirstOrDefault(x => x.Email == admin.Email && x.Password == admin.Password);
            if (adminInfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,admin.Email)
                };

                var userIdentity = new ClaimsIdentity(claims,"admin");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index","AdminHome");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Login","AdminHome");
        }
    }
}
