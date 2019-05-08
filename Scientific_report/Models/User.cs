using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scientific_report.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public int RoleId { get; set; }
        virtual public Teacher Teacher { get; set; }
        virtual public Admin Admin { get; set; }
        virtual public Manager Manager { get; set; }
        public void setPassword(string password) {
            this.Password = password;
        }
    }
}
