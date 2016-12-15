using System.Linq;
using InternshipAuthenticationService.Models.EFModels;
using System.Data.Entity;
using InternshipAuthenticationService.Repository;

namespace InternshipAuthenticationService.DAL
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthenticationServiceDbContext db;

        public RoleRepository(AuthenticationServiceDbContext context)
        {
            this.db = context;
        }

        public IQueryable<Role> GetAll()
        {
            return db.Roles;
        }

        public Role GetById(int roleId)
        {
            return db.Roles.FirstOrDefault(s => s.Id == roleId);
        }

        public void Create(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public void Update(Role role)
        {
            db.Entry(role).State = EntityState.Modified;
        }

        public void Delete(Role role)
        {
            Role newRole = db.Roles.FirstOrDefault(s => s.RoleName == role.RoleName);
            if (newRole != null)
                db.Roles.Remove(newRole);
        }
    }
}
