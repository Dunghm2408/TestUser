using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;
using Test2.Services;

namespace Test2.Controllers
{
    public class UserController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserSvc _userSvc;
        public UserController(IWebHostEnvironment webHostEnvironment,
            IUserSvc userSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _userSvc = userSvc;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View(_userSvc.GetUserAll());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = _userSvc.GetUser(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                _userSvc.AddUser(user);
                return RedirectToAction(nameof(Details), new { id = user.UserID});
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userSvc.GetUser(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userSvc.EditUser(id, user);
                    return RedirectToAction(nameof(Details), new { id = user.UserID });
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
