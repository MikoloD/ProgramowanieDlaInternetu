using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RpgApplication.Areas.Identity.Data;
using RpgApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Controllers
{
    public class CharacterCreationController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly DatabaseContext _context;
        public CharacterCreationController(UserManager<UserModel> userManager, DatabaseContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            List<MistbornCharacterSheetModel> MyCharacters = _context.MistbornCharacters.Where(x => x.UserName == _userManager.GetUserName(User)).ToList();
            ViewBag.MyCharacters = MyCharacters;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Id)
        {
            return RedirectToAction(nameof(CharacterSheet),new {CharacterId= int.Parse(Id) });
        }
        public IActionResult CharacterSheet(int CharacterId)
        {
            MistbornCharacterSheetModel model = _context.MistbornCharacters.First(x => x.Id == CharacterId);
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MistbornCharacterSheetModel model)
        {
            model.UserName = _userManager.GetUserName(User);
            model.UserId = _userManager.GetUserId(User);
            _context.MistbornCharacters.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
