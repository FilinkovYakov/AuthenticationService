﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternshipAuthenticationService.Client.AuthenticationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticationService.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AuthorizationUser", ReplyAction="http://tempuri.org/IAuthenticationService/AuthorizationUserResponse")]
        InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User> AuthorizationUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AuthorizationUser", ReplyAction="http://tempuri.org/IAuthenticationService/AuthorizationUserResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>> AuthorizationUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/CreateUser", ReplyAction="http://tempuri.org/IAuthenticationService/CreateUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(InternshipAuthenticationService.Models.Faults.InvalidRoleFault), Action="http://tempuri.org/IAuthenticationService/CreateUserInvalidRoleFaultFault", Name="InvalidRoleFault", Namespace="http://schemas.datacontract.org/2004/07/InternshipAuthenticationService.Models.Fa" +
            "ults")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>))]
        InternshipAuthenticationService.Models.OperationResult.OperationResult CreateUser(InternshipAuthenticationService.Models.ServiceModels.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/CreateUser", ReplyAction="http://tempuri.org/IAuthenticationService/CreateUserResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> CreateUserAsync(InternshipAuthenticationService.Models.ServiceModels.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/UpdateUser", ReplyAction="http://tempuri.org/IAuthenticationService/UpdateUserResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>))]
        InternshipAuthenticationService.Models.OperationResult.OperationResult UpdateUser(InternshipAuthenticationService.Models.ServiceModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/UpdateUser", ReplyAction="http://tempuri.org/IAuthenticationService/UpdateUserResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> UpdateUserAsync(InternshipAuthenticationService.Models.ServiceModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/ChangePassword", ReplyAction="http://tempuri.org/IAuthenticationService/ChangePasswordResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>))]
        InternshipAuthenticationService.Models.OperationResult.OperationResult ChangePassword(InternshipAuthenticationService.Models.ServiceModels.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/ChangePassword", ReplyAction="http://tempuri.org/IAuthenticationService/ChangePasswordResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> ChangePasswordAsync(InternshipAuthenticationService.Models.ServiceModels.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/DeleteUser", ReplyAction="http://tempuri.org/IAuthenticationService/DeleteUserResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>))]
        InternshipAuthenticationService.Models.OperationResult.OperationResult DeleteUser(InternshipAuthenticationService.Models.ServiceModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/DeleteUser", ReplyAction="http://tempuri.org/IAuthenticationService/DeleteUserResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> DeleteUserAsync(InternshipAuthenticationService.Models.ServiceModels.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/SearchUser", ReplyAction="http://tempuri.org/IAuthenticationService/SearchUserResponse")]
        InternshipAuthenticationService.Models.ServiceModels.User[] SearchUser(string login, string fullName, string role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/SearchUser", ReplyAction="http://tempuri.org/IAuthenticationService/SearchUserResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.ServiceModels.User[]> SearchUserAsync(string login, string fullName, string role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAll", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllResponse")]
        InternshipAuthenticationService.Models.ServiceModels.User[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAll", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.ServiceModels.User[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AddRole", ReplyAction="http://tempuri.org/IAuthenticationService/AddRoleResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>))]
        InternshipAuthenticationService.Models.OperationResult.OperationResult AddRole(string roleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AddRole", ReplyAction="http://tempuri.org/IAuthenticationService/AddRoleResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> AddRoleAsync(string roleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAllRoles", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllRolesResponse")]
        InternshipAuthenticationService.Models.ServiceModels.Role[] GetAllRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAllRoles", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllRolesResponse")]
        System.Threading.Tasks.Task<InternshipAuthenticationService.Models.ServiceModels.Role[]> GetAllRolesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : InternshipAuthenticationService.Client.AuthenticationService.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<InternshipAuthenticationService.Client.AuthenticationService.IAuthenticationService>, InternshipAuthenticationService.Client.AuthenticationService.IAuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User> AuthorizationUser(string login, string password) {
            return base.Channel.AuthorizationUser(login, password);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult<InternshipAuthenticationService.Models.ServiceModels.User>> AuthorizationUserAsync(string login, string password) {
            return base.Channel.AuthorizationUserAsync(login, password);
        }
        
        public InternshipAuthenticationService.Models.OperationResult.OperationResult CreateUser(InternshipAuthenticationService.Models.ServiceModels.User user, string password) {
            return base.Channel.CreateUser(user, password);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> CreateUserAsync(InternshipAuthenticationService.Models.ServiceModels.User user, string password) {
            return base.Channel.CreateUserAsync(user, password);
        }
        
        public InternshipAuthenticationService.Models.OperationResult.OperationResult UpdateUser(InternshipAuthenticationService.Models.ServiceModels.User user) {
            return base.Channel.UpdateUser(user);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> UpdateUserAsync(InternshipAuthenticationService.Models.ServiceModels.User user) {
            return base.Channel.UpdateUserAsync(user);
        }
        
        public InternshipAuthenticationService.Models.OperationResult.OperationResult ChangePassword(InternshipAuthenticationService.Models.ServiceModels.User user, string password) {
            return base.Channel.ChangePassword(user, password);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> ChangePasswordAsync(InternshipAuthenticationService.Models.ServiceModels.User user, string password) {
            return base.Channel.ChangePasswordAsync(user, password);
        }
        
        public InternshipAuthenticationService.Models.OperationResult.OperationResult DeleteUser(InternshipAuthenticationService.Models.ServiceModels.User user) {
            return base.Channel.DeleteUser(user);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> DeleteUserAsync(InternshipAuthenticationService.Models.ServiceModels.User user) {
            return base.Channel.DeleteUserAsync(user);
        }
        
        public InternshipAuthenticationService.Models.ServiceModels.User[] SearchUser(string login, string fullName, string role) {
            return base.Channel.SearchUser(login, fullName, role);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.ServiceModels.User[]> SearchUserAsync(string login, string fullName, string role) {
            return base.Channel.SearchUserAsync(login, fullName, role);
        }
        
        public InternshipAuthenticationService.Models.ServiceModels.User[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.ServiceModels.User[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public InternshipAuthenticationService.Models.OperationResult.OperationResult AddRole(string roleName) {
            return base.Channel.AddRole(roleName);
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.OperationResult.OperationResult> AddRoleAsync(string roleName) {
            return base.Channel.AddRoleAsync(roleName);
        }
        
        public InternshipAuthenticationService.Models.ServiceModels.Role[] GetAllRoles() {
            return base.Channel.GetAllRoles();
        }
        
        public System.Threading.Tasks.Task<InternshipAuthenticationService.Models.ServiceModels.Role[]> GetAllRolesAsync() {
            return base.Channel.GetAllRolesAsync();
        }
    }
}
