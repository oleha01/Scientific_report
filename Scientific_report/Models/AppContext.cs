using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Scientific_report.Models
{
    public class AppContext:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkEnum> WorkEnums { get; set; }
        public DbSet<Work_User> Work_Users { get; set; }
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }
       
    }
}

