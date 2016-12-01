using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("DbConnection")
        { }

        public DbSet<ODBModels.User> Users { get; set; }
        public DbSet<ODBModels.Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ODBModels.User>().
                HasMany(c => c.Roles).
                WithMany(p => p.Users).
                Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                        m.ToTable("UsersRoles");
                    });
            base.OnModelCreating(modelBuilder);
        }
    }
}

