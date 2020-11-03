﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
