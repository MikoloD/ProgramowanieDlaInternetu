﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApplication.Areas.Identity.Data
{
    public class Role :IdentityRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
