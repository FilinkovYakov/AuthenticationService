using System;
using System.Collections.Generic;
using System.Linq;
using InternshipAuthenticationService.Models.ServiceModels;

namespace InternshipAuthenticationService.Client
{
    public class ClientUser
    {
        public ClientUser() { }

        public ClientUser(User user)
        {
            Id = user.Id;
            Login = user.Login;
            FullName = user.FullName;
            Role = user.Roles.First().RoleName;
        }

        public int Id { get; set; }

        public String Login { get; set; }

        public String FullName { get; set; }

        public String Role { get; set; }
    }
}