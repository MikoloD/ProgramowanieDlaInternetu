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

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MistbornCharacterSheetModel model)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.MistbornCharacters.Add(model);
            }
            return View();
        }
    }
}
