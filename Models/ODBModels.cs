using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ODBModels
{

    public class User
    {
        public User() { }

        public int Id { get; set; }

        public String Login { get; set; }

        public String FullName { get; set; }

        public virtual IList<Role> Roles { get; set; }

        public String Password { get; set; }

        public String Salt { get; set; }
    }
    

    public class Role
    {
        public Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public int Id { get; set; }

        public String RoleName { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
