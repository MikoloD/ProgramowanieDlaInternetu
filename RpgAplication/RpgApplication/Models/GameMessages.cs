using RpgApplication.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Models
{
    public class GameMessages
    {
        [Key]
        public int Id { get; set; }
        public string GameId { get; set; }
        public string FromUserId { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        [Display(Name = "Poziom umiejętności")]
        public int Roll { get; set; }
        [Display(Name = "Liczba kości")]
        public int Dices { get; set; }
        public virtual GameModel Game { get; set; }
        public virtual UserModel User { get; set; }
    }
}
