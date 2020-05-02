﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Data.Models
{
    public class User : IdentityUser
    {
        public List<Evaluation> Evaluation { get; set; }
    }
}
