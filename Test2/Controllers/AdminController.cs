using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test2.Constant;
using Test2.Models;
using Test2.Models.ViewModels;
using Test2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserSvc _userSvc;
        public AdminController(IWebHostEnvironment webHostEnvironment,
            IUserSvc userSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _userSvc = userSvc;
        }

        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl)
        {
            string userName = HttpContext.Session.GetString(SessionKey.User.UserFullName);
            if (userName != null && userName != "")
            {
                return RedirectToAction("Index", "Home");
            }
            #region Hiển thị Login
            ViewLogin login = new ViewLogin();
            login.ReturnUrl = returnUrl;
            return View(login);
            #endregion
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(ViewLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                User user = _userSvc.Login(viewLogin);
                if (user != null)
                {
                    HttpContext.Session.SetString(SessionKey.User.UserFullName,user.UserFullName);
                    HttpContext.Session.SetString(SessionKey.User.UserContext,
                        JsonConvert.SerializeObject(user));

                    return RedirectToAction(nameof(Index), "Admin");
                }
            }
            return View(viewLogin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKey.User.UserFullName);
            HttpContext.Session.Remove(SessionKey.User.UserContext);
            return RedirectToAction(nameof(Index), "Admin");
        }
    }
}

