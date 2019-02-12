using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthPOC.Model;

namespace AuthPOC.DAL
{
    public class PermissionDbContext : DbContext
    {
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<PermissionAttrib> PermissionAttribs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
