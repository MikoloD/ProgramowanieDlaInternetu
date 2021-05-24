using RpgApplication.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpgApplication.Models
{
    public class GameModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name ="Gra")]
        public string GameName { get; set; }
        [Display(Name = "Zdjęcie")]
        public string PhotoURL { get; set; }
        //[JsonIgnore]
        public virtual IEnumerable<GameMessages> Messages { get; set; }
        public virtual IEnumerable<GameUser> Players { get; set; }
    }
}
