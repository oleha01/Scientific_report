﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific_report.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string  Name { get; set; }
        public string Patronymic { get; set; } //По-Батькові
        public string Position { get; set; }
        public string Chair { get; set; }
        public int Year_of_birth { get; set; }
        public int Year_of_graduation { get; set; }
        public string Degree { get; set; }
        public int Year_of_Protection { get; set; }
        public string Academic_status { get; set; }
        public int Year_of_Assignment { get; set; }
        public int CafedraId { get; set; }
        virtual public Cafedra Cafedra { get; set; }
        public int UserId { get; set; }
        virtual public User User { get; set; }
        virtual public List<Work_User> Work_Users { get; set; }
    }
    
}
