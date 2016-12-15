using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InternshipAuthenticationService.Models.OperationResult
{
    [DataContract]
    public enum OperationErrors
    {
        [EnumMember]
        AutorizationFiledErr,
        [EnumMember]
        NullErr,
        [EnumMember]
        LoginErr,
        [EnumMember]
        FullNameErr,
        [EnumMember]
        RoleErr,
        [EnumMember]
        PassErr,        
        [EnumMember]
        UserExistErr,
        [EnumMember]
        UserNotExistErr,
        [EnumMember]
        UsersNotExistErr
    }
}