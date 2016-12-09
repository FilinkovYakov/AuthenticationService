using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace InternshipAuthenticationService.Models.Faults
{
    [DataContract]
    public class InvalidRoleFault
    {
        [DataMember]
        public string Message { get; set; }
        public InvalidRoleFault()
        {
        }
        public InvalidRoleFault(string error)
        {
            Message = error;
        }
    }
}
