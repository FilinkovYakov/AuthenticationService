using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IRepository;

namespace DAL
{
    public class RoleRepository : IRoleRepository
    {
        private DBContext db;

        public RoleRepository(DBContext context)
        {
            this.db = context;
        }

        public IQueryable<ODBModels.Role> GetAll()
        {
            return db.Roles;
        }

        public ODBModels.Role Get(ODBModels.Role role)
        {
            return db.Roles.Where(s => s.RoleName == role.RoleName).FirstOrDefault<ODBModels.Role>();
        }

        public void Create(ODBModels.Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public void Update(ODBModels.Role role)
        {
            db.Entry(role).State = EntityState.Modified;
        }

        public void Delete(ODBModels.Role role)
        {
            ODBModels.Role newRole = db.Roles.Where(s => s.RoleName == role.RoleName).FirstOrDefault<ODBModels.Role>();
            if (newRole != null)
                db.Roles.Remove(newRole);
        }
    }
}
