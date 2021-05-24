﻿using Microsoft.AspNetCore.Identity;
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
            var CurrentGame = _context.GameMessages
                .Include(x=>x.User)
                .ThenInclude(x=>x.Characters)
                .Where(x => x.GameId == Id).ToList();
            return View(CurrentGame);
        }
        [HttpPost]
        public IActionResult Create(GameModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            _context.Games.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}