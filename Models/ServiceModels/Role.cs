using System;
using System.Runtime.Serialization;

namespace InternshipAuthenticationService.Models.ServiceModels
{
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
