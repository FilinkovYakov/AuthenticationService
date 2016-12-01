using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService
{
    [DataContract]
    public class OperationResult
    {
        private List<OperationError> _errors = new List<OperationError>();

        public OperationResult()
        {
        }
        
        public bool Success { get { return !Errors.Any(); } }

        [DataMember]
        public OperationError[] Errors { get { return _errors.ToArray(); } }

        public void AddResultCode(OperationError errCode) {
            _errors.Add(errCode);
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