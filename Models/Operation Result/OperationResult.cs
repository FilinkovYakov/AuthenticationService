using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InternshipAuthenticationService.Models.OperationResult
{
    [DataContract]
    public class OperationResult
    {
        public OperationResult()
        {
            Errors = new List<OperationErrors>();
        }
        
        public bool Success { get { return !Errors.Any(); } }

        [DataMember]
        public IList<OperationErrors> Errors { get; set; }

        public void AddResultCode(OperationErrors errCode) {
            Errors.Add(errCode);
        }
    }

    [DataContract(Name = "OperationResultOf{0}")]
    public class OperationResult<T> : OperationResult
    {
        [DataMember]
        public T Result { get; set; }
    }

    
}