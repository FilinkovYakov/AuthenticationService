using InternshipAuthenticationService.Models.EFModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace InternshipAuthenticationService.DAL
{
    public class AuthenticationServiceDbContext : DbContext
    {
        public AuthenticationServiceDbContext()
            : base("Mirantis.AuthenticationService")
        {
            Database.SetInitializer(new AuthenticationServiceDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                        {
                            new IndexAttribute("Idx_RoleName") { IsUnique = true }
                        }));

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new[]
                        {
                            new IndexAttribute("Idx_Login") { IsUnique = true }
                        }));

            modelBuilder.Entity<User>()
                .HasMany(c => c.Roles)
                .WithMany(p => p.Users)
                .Map(
                    m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                        m.ToTable("UsersRoles");
                    });
            base.OnModelCreating(modelBuilder);
        }

        private class AuthenticationServiceDbInitializer : IDatabaseInitializer<AuthenticationServiceDbContext>
        {
            public void InitializeDatabase(AuthenticationServiceDbContext context)
            {
                try
                {
                    Role adminRole = context.Roles.Add(new Role { RoleName = "Admin" });
                    context.Roles.Add(new Role { RoleName = "Manager" });
                    context.Roles.Add(new Role { RoleName = "Engineer" });

                    context.Users.Add(new User
                    {
                        Login = "Admin",
                        FullName = "Administrator",
                        Salt = "SNbNJ3F/vAr89D0nSB9boe0K9VhmlQ276dTCabSR/yQ=",
                        Password = "FM5FwhMbXrkwpQ6hBBCM8Q==",
                        Roles = new List<Role> { adminRole }
                    });

                    context.SaveChanges();
                }
                catch
                {
                    // ignore error
                }
            }
        }
    }
}

