﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalAD_POC.Models
{
    public class ADSearchDTO
    {
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool isGroup { get; set; }
    }
}
