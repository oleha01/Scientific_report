using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Scientific_report.Models.TeacherProfile
{
    public class RegisterTeacher
   
    {
        [Required]
        public string TeacherName { get; set; }

        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Required]
        [UIHint("password")]
        public string PasswordRepeat { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public int Year_of_graduation { get; set; }

        [Required]
        public int Year_of_birth { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public int Year_of_Protection { get; set; }

        [Required]
        public string Academic_status { get; set; }

        [Required]
        public int Year_of_Assignment { get; set; }

        

    }
}
