using RpgApplication.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Models
{
    public class MistbornCharacterSheetModel
    {
        [Key]
        public int Id { get; set; }
        public string GamesId { get; set; }
        // Basic Informations
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Imię Postaci")]
        public string CharacterName { get; set; }
        [Display(Name = "Rola postaci")]
        public string CharacterRole { get; set; }
        [Display(Name = "Cecha")]
        public string Trait { get; set; }
        [Display(Name = "Awatar")]
        public string CharacterAvatarURL { get; set; }
        // Skills
        [Display(Name = "Percepcja")]
        public int Percepcion { get; set; } = 2;
        [Display(Name = "Motoryka")]
        public int Motorics { get; set; } = 2;
        [Display(Name = "Krzepa")]
        public int Physique { get; set; } = 2;
        [Display(Name = "Skupienie")]
        public int Psyche { get; set; } = 2;
        [Display(Name = "Inteligencja")]
        public int Intellect { get; set; } = 2;
        [Display(Name = "Prezencja")]
        public int Presence { get; set; } = 2;
        //Allomancy
        [Display(Name = "Stal")]
        public int Steel { get; set; } = 0;
        [Display(Name = "Żelazo")]
        public int Iron { get; set; } = 0;
        [Display(Name = "Ołów")]
        public int Lead { get; set; } = 0;
        [Display(Name = "Cyna")]
        public int Tin { get; set; } = 0;
        [Display(Name = "Cynk")]
        public int Zinc { get; set; } = 0;
        [Display(Name = "Mosiądz")]
        public int Brass { get; set; } = 0;
        [Display(Name = "Miedź")]
        public int Copper { get; set; } = 0;
        [Display(Name = "Brąz")]
        public int Bronze { get; set; } = 0;
        //Abilities 
        [Display(Name = "Broń Biała")]
        public int MeleWeapon { get; set; } = 0;
        [Display(Name = "Broń Dystansowa")]
        public int RangeWeapon { get; set; } = 0;
        [Display(Name = "Broń Rzucana")]
        public int ThrowingWeapon { get; set; } = 0;
        [Display(Name = "Unik")]
        public int Evede { get; set; } = 0;
        [Display(Name = "Parowanie")]
        public int Parry { get; set; } = 0;
        [Display(Name = "Blok")]
        public int Block { get; set; } = 0;
        [Display(Name = "Kondycja")]
        public int Condition { get; set; } = 0;
        [Display(Name = "Skradanie")]
        public int Steath { get; set; } = 0;
        [Display(Name = "Złodziejstwo")]
        public int Thievery { get; set; } = 0;
        [Display(Name = "Wypatrywanie")]
        public int Observatione { get; set; } = 0;
        [Display(Name = "Fałszerstwo")]
        public int Forgery { get; set; } = 0;
        [Display(Name = "Alchemia")]
        public int Alchemy { get; set; } = 0;
        [Display(Name = "Rzemisło")]
        public int Crafting { get; set; } = 0;
        [Display(Name = "Medycyna")]
        public int Medicine { get; set; } = 0;
        [Display(Name = "Malarstwo")]
        public int Painting { get; set; } = 0;
        [Display(Name = "Muzyka")]
        public int Music { get; set; } = 0;
        [Display(Name = "Wiedza")]
        public int Knowledge { get; set; } = 0;
        [Display(Name = "Heraldyka")]
        public int Heraldry { get; set; } = 0;
        [Display(Name = "Opanowanie")]
        public int Calm { get; set; } = 0;
        [Display(Name = "Empatia")]
        public int Empathy { get; set; } = 0;
        [Display(Name = "Taktyka")]
        public int Tactics { get; set; } = 0;
        [Display(Name = "Charyzma")]
        public int Charisma { get; set; } = 0;
        [Display(Name = "Zastraszanie")]
        public int Intimidate { get; set; } = 0;
        [Display(Name = "Perswazja")]
        public int Persuasion { get; set; } = 0;
        public virtual UserModel UserModel { get; set; }
    }
}
