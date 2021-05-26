using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApplication.Areas.Identity.Data;
using RpgApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Controllers
{
    public class GamesController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly UserManager<UserModel> _signInManager;
        private readonly DatabaseContext _context;
        public GamesController(UserManager<UserModel> userManager, UserManager<UserModel> signInManager, DatabaseContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Games);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet("ShowGame/{Id}")]
        public IActionResult ShowGame(string Id)
        {
            ViewBag.MyMessage = new GameMessages() { GameId = Id };
            var CurrentGame = _context.GameMessages
                .Include(x => x.User)
                .ThenInclude(x => x.Characters)
                .Where(x => x.GameId == Id).ToList();
            return View(CurrentGame);
        }
        [HttpPost]
        public IActionResult AddMessage(string GameId, string message)
        {
            GameMessages model = new GameMessages();
            model.GameId = GameId;
            model.Message = message;
            model.FromUserId = _signInManager.GetUserId(User);
            model.MessageDate = DateTime.Now;
            _context.GameMessages.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowGame), new { Id = model.GameId });
        }
        [HttpPost]
        public IActionResult Create(GameModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            _context.Games.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AddUserToGame(string Id,string warning="")
        {
            List<MistbornCharacterSheetModel> PlayersThatCanBeAdded = _context.MistbornCharacters.Where(x => x.GamesId != Id).ToList();
            ViewBag.Players = PlayersThatCanBeAdded;
            ViewBag.GameId = Id;
            ViewBag.Warning = warning;
            return View();
        }
        [HttpPost]
        public IActionResult AddUserToGamePost(string Id, string GameId)
        {
            MistbornCharacterSheetModel SelectedCharacter = _context.MistbornCharacters.FirstOrDefault(x => x.Id == int.Parse(Id));
            _context.MistbornCharacters.FirstOrDefault(x => x.Id == int.Parse(Id)).GamesId = GameId;
            var selectedUserId = _context.Users.FirstOrDefault(x => x.Id == SelectedCharacter.UserId).Id;
            bool flag = true;
            foreach (var item in _context.GameUsers)
            {
                if (item.GameId == GameId && item.UserId == selectedUserId)
                    return RedirectToAction(nameof(AddUserToGame),
                        new { Id = GameId,warning="Ten użytkownik uczestniczy już w tej grze" });
            }
            if (flag == true)
            {
                GameUser player = new GameUser();
                player.GameId = GameId;
                player.UserId = selectedUserId;
                _context.GameUsers.Add(player);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}