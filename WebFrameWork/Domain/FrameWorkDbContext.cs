using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Template.Web.Domain
{
    public class FrameWorkDbContext : DbContext
    {
        public FrameWorkDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<LogAction> LogActions { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}