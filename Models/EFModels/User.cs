using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipAuthenticationService.Models.EFModels
{
    public class User
    {
        public User() { }

        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public String Login { get; set; }

        public String FullName { get; set; }

        public virtual List<Role> Roles { get; set; }

        public String Password { get; set; }

        public String Salt { get; set; }
    }
}
