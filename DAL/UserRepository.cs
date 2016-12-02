using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IRepository;
using Models.Exceptions;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext db;

        public UserRepository(DBContext context)
        {
            this.db = context;
        }

        public IQueryable<ODBModels.User> GetAll()
        {
            return db.Users.Include(o => o.Roles);
        }

        public IEnumerable<ODBModels.User> Search(String login, String fullName, String role)
        {

            IEnumerable<ODBModels.User> users = null;
            if (!login.Equals(""))
                users = db.Users.Include(o => o.Roles).Where(s => s.Login == login);
            else if (!fullName.Equals("") && !role.Equals(""))
            {
                users = db.Users.Include(o => o.Roles.First<ODBModels.Role>().RoleName == role).Where(s => s.Login == login);
            }
            else if (!fullName.Equals(""))
            {
                users = db.Users.Include(o => o.Roles).Where(s => s.FullName == fullName);
            }
            else if (!role.Equals(""))
            {
                users = db.Users.Include(o => o.Roles.First<ODBModels.Role>().RoleName == role);
            }
            return users;
        }

        public ODBModels.User GetById(int userId)
        {
            return db.Users.Where(s => s.Id == userId).FirstOrDefault<ODBModels.User>();
        }

        public ODBModels.User GetByLogin(string login)
        {
            return db.Users.Where(s => s.Login == login).FirstOrDefault<ODBModels.User>();
        }        

        public void Create(ODBModels.User user)
        {
            UpdateUserRoles(user);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(ODBModels.User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(ODBModels.User user)
        {
            ODBModels.User newUser = db.Users.Where(s => s.Login == user.Login).FirstOrDefault<ODBModels.User>();
            if (newUser != null)
                db.Users.Remove(newUser);
            db.SaveChanges();
        }

        private void UpdateUserRoles(ODBModels.User user)
        {
            string[] roles = user.Roles.Select(r => r.RoleName).Distinct().ToArray();
            List<ODBModels.Role> rolesList = db.Roles.Where(r => roles.Contains(r.RoleName)).ToList();
            if (roles.Length != rolesList.Count)
                throw new InvalidRoleException("This is role not exists");

            user.Roles = rolesList;
        }
    }
}
