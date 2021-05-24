using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Models
{
    public class GameModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Gra")]
        public string GameName { get; set; }
        [Display(Name = "Zdjęcie")]
        public string PhotoURL { get; set; }
        [Display(Name = "Lokacja")]
        public string GameURL { get; set; }
    }
}
