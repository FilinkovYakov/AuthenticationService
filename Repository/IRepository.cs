using System;
using System.Collections.Generic;
using System.Linq;
using InternshipAuthenticationService.Models.EFModels;

namespace InternshipAuthenticationService.Repository
{
    public interface IRepository<T, TId> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(TId id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }

    public interface IUserRepository : IRepository<User, int>
    {

        User GetByLogin(String login);
        IEnumerable<User> Search(String login, String fullName, String role);
        void ChangePassword(User newUser);
    }

    public interface IRoleRepository : IRepository<Role, int>
    { }
}
