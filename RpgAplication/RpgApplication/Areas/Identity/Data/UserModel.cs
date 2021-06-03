using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RpgApplication.Models;

namespace RpgApplication.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the UserModel class
    public class UserModel : IdentityUser
    {
        public virtual IEnumerable<GameUser> Games { get; set; }
        public virtual IEnumerable<GameMessages> GameMessages { get; set; }
        public virtual IEnumerable<MistbornCharacterSheetModel> Characters { get; set; }

    }
}
