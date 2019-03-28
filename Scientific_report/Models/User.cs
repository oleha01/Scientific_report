using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scientific_report.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IRole Role { get; set; }
    }
}
