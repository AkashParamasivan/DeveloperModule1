using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DeveloperModule.Models
{
    public class ReleaseManagementContext:DbContext
    {
        public ReleaseManagementContext() : base("con")
        {

        }
        public DbSet<LoginDetails> EloginDetails { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Bug> bugs { get; set; }
    }
}