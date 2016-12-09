using System.Collections.Generic;
using System.ServiceModel;
using InternshipAuthenticationService.Models.ServiceModels;
using InternshipAuthenticationService.Models.OperationResult;
using InternshipAuthenticationService.Models.Faults;

namespace InternshipAuthenticationService.AuthenticationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthentication_Service_WCF" in both code and config file together.
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        OperationResult<User> AuthorizationUser(string login, string password);

        [OperationContract]
        [FaultContract(typeof(InvalidRoleFault))]
        OperationResult CreateUser(User user, string password);   

        [OperationContract]
        OperationResult UpdateUser(User user);

        [OperationContract]
        OperationResult ChangePassword(User user, string password);

        [OperationContract]
        OperationResult DeleteUser(User user);

        [OperationContract]
        IEnumerable<User> SearchUser(string login, string fullName, string role);

        [OperationContract]
        IEnumerable<User> GetAll();

        [OperationContract]
        OperationResult AddRole(string roleName);

        [OperationContract]
        IEnumerable<Role> GetAllRoles();
    }
}
