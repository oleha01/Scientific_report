﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scientific_report.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int UserId { get; set; }
        virtual public User User { get; set; }
    }
}
