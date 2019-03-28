using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Scientific_report.Models
{
    public class AppReportContext:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkEnum> WorkEnums { get; set; }
        public DbSet<Work_User> Work_Users { get; set; }
        public DbSet<Facultet> Facultets { get; set; }
        public DbSet<Cafedra> Cafedras { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public AppReportContext(DbContextOptions<AppReportContext> options)
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

