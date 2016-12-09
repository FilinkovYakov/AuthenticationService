using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipAuthenticationService.Models.EFModels
{
    public class Role
    {
        public Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }

        [Key]
        public int Id { get; set; }
        
        [MaxLength(256)]
        public String RoleName { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
