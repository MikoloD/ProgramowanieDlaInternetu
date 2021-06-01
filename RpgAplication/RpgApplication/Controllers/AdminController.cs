using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RpgApplication.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly DatabaseContext _context;

        public AdminController(UserManager<UserModel> userManager, DatabaseContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult AdminPanel()
        {
            ViewBag.Players = _context.Users.ToList();
            ViewBag.PlayerRoles = _context.Roles.Where(
                x => x.Id != 3.ToString())
                .ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AdminPanel(string UserId,string RoleId)
        {
            ViewBag.Players = _context.Users.ToList();
            ViewBag.PlayerRoles = _context.Roles.Where(
                x => x.Id != 3.ToString())
                .ToList();
            return View();
        }

    }
}
