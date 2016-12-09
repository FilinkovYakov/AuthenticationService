using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Security;

namespace InternshipAuthenticationService.Models.ServiceModels
{
    [DataContract]
    public class User
    {
        public User() { }

        public User(string login, string fullName, List<Role> roles)
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
        public List<Role> Roles { get; set; }
    }
}
