﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaoSun.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Mobileno { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Tasks_History> Tasks_Histories { get; set; }
    }
}
