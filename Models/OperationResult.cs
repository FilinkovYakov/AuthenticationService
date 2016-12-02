using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class OperationResult
    {
        public OperationResult()
        {
            Errors = new List<OperationError>();
        }
        
        public bool Success { get { return !Errors.Any(); } }

        [DataMember]
        public IList<OperationError> Errors { get; set; }

        public void AddResultCode(OperationError errCode) {
            Errors.Add(errCode);
        }
    }

    [DataContract(Name = "OperationResultOf{0}")]
    public class OperationResult<T> : OperationResult
    {
        [DataMember]
        public T Result { get; set; }
    }

    [DataContract]
    public enum OperationError
    {
        [EnumMember]
        LoginErr,
        [EnumMember]
        FullNameErr,
        [EnumMember]
        RoleErr,
        [EnumMember]
        PassErr,
        [EnumMember]
        UserExistsErr
    }
}