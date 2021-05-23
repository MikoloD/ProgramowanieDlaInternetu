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
        // Basic Informations
        public string UserName { get; set; }
        [Display(Name = "Imię Postaci")]
        public string CharacterName { get; set; }
        [Display(Name = "Rola postaci")]
        public string CharacterRole { get; set; }
        [Display(Name = "Cecha")]
        public string Trait { get; set; }
        // Skills
        public int Percepcion { get; set; } = 2;
        public int Motorics { get; set; } = 2;
        public int Physique { get; set; } = 2;
        public int Psyche { get; set; } = 2;
        public int Intellect { get; set; } = 2;
        public int Presence { get; set; } = 2;
        //Allomancy
        public int Steel { get; set; } = 0;
        public int Iron { get; set; } = 0;
        public int Lead { get; set; } = 0;
        public int Tin { get; set; } = 0;
        public int Zinc { get; set; } = 0;
        public int Brass { get; set; } = 0;
        public int Copper { get; set; } = 0;
        public int Bronze { get; set; } = 0;
        //Abilities 
        public int MeleWeapon { get; set; } = 0;
        public int RangeWeapon { get; set; } = 0;
        public int ThrowingWeapon { get; set; } = 0;
        public int Evede { get; set; } = 0;
        public int Parry { get; set; } = 0;
        public int Block { get; set; } = 0;
        public int Condition { get; set; } = 0;
        public int Steath { get; set; } = 0;
        public int HorseRiding { get; set; } = 0;
        public int Thievery { get; set; } = 0;
        public int Observatione { get; set; } = 0;
        public int Forgery { get; set; } = 0;
        public int Alchemy { get; set; } = 0;
        public int Crafting { get; set; } = 0;
        public int Medicine { get; set; } = 0;
        public int Painting { get; set; } = 0;
        public int Music { get; set; } = 0;
        public int Sailing { get; set; } = 0;
        public int Knowledge { get; set; } = 0;
        public int Heraldry { get; set; } = 0;
        public int Calm { get; set; } = 0;
        public int Empathy { get; set; } = 0;
        public int Tactics { get; set; } = 0;
        public int Charisma { get; set; } = 0;
        public int Credibility { get; set; } = 0;
        public int Intimidate { get; set; } = 0;
        public int Persuasion { get; set; } = 0;
    }
}
