using RpgApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Areas.Identity.Data
{
    public class GameUser
    {
        public string UserId { get; set; }
        public string GameId { get; set; }

        public virtual GameModel Game { get; set; }
        public virtual UserModel UserModel { get; set; }
    }
}
