﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Employee Employee { get; set; }
    }
}
