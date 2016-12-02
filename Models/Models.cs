using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class User
    {
        public User() { }

        public User(string login, string fullName, IList<Role> roles)
        {
            Login = login;
            FullName = fullName;
            Roles = roles;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String Login { get; set; }

        [DataMember]
        public String FullName { get; set; }

        [DataMember]
        public IList<Role> Roles { get; set; }
    }


    [DataContract]
    public class Role
    {
        public Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String RoleName { get; set; }
    }
}
