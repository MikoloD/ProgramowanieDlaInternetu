using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RpgApplication.Areas.Identity.Data;
using RpgApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.SignalR.Client;

namespace RpgApplication.Controllers
{
    public class GamesController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly UserManager<UserModel> _signInManager;
        private readonly DatabaseContext _context;
        private readonly IJSRuntime _jSRuntime;
        public static HubConnection HubClient { get; set; }
        public GamesController(UserManager<UserModel> userManager, UserManager<UserModel> signInManager, DatabaseContext context, IJSRuntime jSRuntime)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _jSRuntime = jSRuntime;
        }
        public IActionResult Index()
        {
            ViewBag.IsAdmin = User.IsInRole("Administrator");
            return View(_context.Games);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet("ShowGame/{Id}")]
        public async Task <IActionResult> ShowGame(string Id)
        {
            var CurrentGame = _context.GameMessages
               .Include(x => x.User)
               .ThenInclude(x => x.Characters)
               .Where(x => x.GameId == Id).ToList();

            if (HubClient is null) 
                HubClient = new HubConnectionBuilder().WithUrl(new Uri("http://localhost:6390/chatHub"))
                    .Build();

            if (HubClient.State==HubConnectionState.Disconnected)
                await HubClient.StartAsync();

            HubClient.On<string,string>("ReceiveMessage", (user,message) =>
            {
                CurrentGame.Add(new GameMessages { GameId = Id, Message = message, FromUserId = user, MessageDate = DateTime.Now });
            });

            GameMessages myMessge = new GameMessages() { GameId = Id };
            ViewBag.Messages = CurrentGame;
            ViewBag.UserName = _signInManager.GetUserName(User);
            string userId = _signInManager.GetUserId(User);
            bool allowedUser = _context.GameUsers.Any(
                x => x.GameId==Id && x.UserId == userId);
            ViewBag.Allowed = allowedUser;
            return View(myMessge);
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(string GameId, string message, int Roll, int Dices)
        {
            Random rnd = new Random();
            int succeses = 0;
            GameMessages model = new GameMessages()
            {
                GameId = GameId,
                Roll = Roll,
                Dices = Dices
            };
            for(int i=0;i<Dices;i++)
            {
                var result = rnd.Next(1, 11);
                if (result == 10) succeses += 2;
                else if (result + Roll > 9) succeses += 1;
                else if (result==1) succeses -= 1;
            }
            if (Dices != 0 || Roll != 0)
                message = message + " [Wynik rzutu: " + succeses.ToString() + "]";
            model.Message = message;
            model.FromUserId = _signInManager.GetUserId(User);
            model.MessageDate = DateTime.Now;
            _context.GameMessages.Add(model);
            _context.SaveChanges();
            await HubClient.SendAsync("SendMessage", model.FromUserId, model.Message);
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
        public IActionResult AddUserToGame(string Id, string warning = "")
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
                        new { Id = GameId, warning = "Ten użytkownik uczestniczy już w tej grze" });
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