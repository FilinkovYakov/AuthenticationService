using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T Get(T item);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }

    public interface IUserRepository : IRepository<ODBModels.User>
    {
        IEnumerable<ODBModels.User> Search(String login, String fullName, String role);
    }

    public interface IRoleRepository : IRepository<ODBModels.Role>
    { }
}
