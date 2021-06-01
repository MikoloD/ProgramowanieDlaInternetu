using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Areas.Identity.Data
{
    public class AddingRoleModel
    {
        public Role Role { get; set; }
        public UserModel User { get; set; }
    }
}
