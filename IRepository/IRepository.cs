using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IRepository<T, TId> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(TId id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }

    public interface IUserRepository : IRepository<ODBModels.User, int>
    {
        ODBModels.User GetByLogin(String login);
        IEnumerable<ODBModels.User> Search(String login, String fullName, String role);
    }

    public interface IRoleRepository : IRepository<ODBModels.Role, int>
    { }
}
