using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RpgAplication.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Nazwa Użytkownika")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
