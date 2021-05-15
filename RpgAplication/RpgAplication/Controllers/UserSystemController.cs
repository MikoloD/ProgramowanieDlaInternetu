using Microsoft.AspNetCore.Mvc;
using RpgAplication.Database;
using RpgAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgAplication.Controllers
{
    public class UserSystemController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                user.RoleId = 4;
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(RegisterSucces));
        }
        public IActionResult RegisterSucces()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            return RedirectToAction(nameof(LoginSucces));
        }
        public IActionResult LoginSucces()
        {
            return View();
        }
    }
}
