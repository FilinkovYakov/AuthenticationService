﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthenticationServiceAndClient.AuthenticationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticationService.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/CreateUser", ReplyAction="http://tempuri.org/IAuthenticationService/CreateUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Models.Faults.InvalidRoleFault), Action="http://tempuri.org/IAuthenticationService/CreateUserInvalidRoleFaultFault", Name="InvalidRoleFault", Namespace="http://schemas.datacontract.org/2004/07/Models.Faults")]
        Models.OperationResult CreateUser(Models.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/CreateUser", ReplyAction="http://tempuri.org/IAuthenticationService/CreateUserResponse")]
        System.Threading.Tasks.Task<Models.OperationResult> CreateUserAsync(Models.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/SearchUser", ReplyAction="http://tempuri.org/IAuthenticationService/SearchUserResponse")]
        ODBModels.User[] SearchUser(string login, string fullName, string role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/SearchUser", ReplyAction="http://tempuri.org/IAuthenticationService/SearchUserResponse")]
        System.Threading.Tasks.Task<ODBModels.User[]> SearchUserAsync(string login, string fullName, string role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAll", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllResponse")]
        ODBModels.User[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAll", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllResponse")]
        System.Threading.Tasks.Task<ODBModels.User[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/UpdateUser", ReplyAction="http://tempuri.org/IAuthenticationService/UpdateUserResponse")]
        void UpdateUser(Models.User user, Models.User newUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/UpdateUser", ReplyAction="http://tempuri.org/IAuthenticationService/UpdateUserResponse")]
        System.Threading.Tasks.Task UpdateUserAsync(Models.User user, Models.User newUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/DeleteUser", ReplyAction="http://tempuri.org/IAuthenticationService/DeleteUserResponse")]
        void DeleteUser(Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/DeleteUser", ReplyAction="http://tempuri.org/IAuthenticationService/DeleteUserResponse")]
        System.Threading.Tasks.Task DeleteUserAsync(Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AuthorizationUser", ReplyAction="http://tempuri.org/IAuthenticationService/AuthorizationUserResponse")]
        Models.User AuthorizationUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AuthorizationUser", ReplyAction="http://tempuri.org/IAuthenticationService/AuthorizationUserResponse")]
        System.Threading.Tasks.Task<Models.User> AuthorizationUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/ChangePassword", ReplyAction="http://tempuri.org/IAuthenticationService/ChangePasswordResponse")]
        bool ChangePassword(Models.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/ChangePassword", ReplyAction="http://tempuri.org/IAuthenticationService/ChangePasswordResponse")]
        System.Threading.Tasks.Task<bool> ChangePasswordAsync(Models.User user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AddRole", ReplyAction="http://tempuri.org/IAuthenticationService/AddRoleResponse")]
        void AddRole(string roleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/AddRole", ReplyAction="http://tempuri.org/IAuthenticationService/AddRoleResponse")]
        System.Threading.Tasks.Task AddRoleAsync(string roleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAllRoles", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllRolesResponse")]
        Models.Role[] GetAllRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/GetAllRoles", ReplyAction="http://tempuri.org/IAuthenticationService/GetAllRolesResponse")]
        System.Threading.Tasks.Task<Models.Role[]> GetAllRolesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : AuthenticationServiceAndClient.AuthenticationService.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<AuthenticationServiceAndClient.AuthenticationService.IAuthenticationService>, AuthenticationServiceAndClient.AuthenticationService.IAuthenticationService {
        
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
        
        public Models.OperationResult CreateUser(Models.User user, string password) {
            return base.Channel.CreateUser(user, password);
        }
        
        public System.Threading.Tasks.Task<Models.OperationResult> CreateUserAsync(Models.User user, string password) {
            return base.Channel.CreateUserAsync(user, password);
        }
        
        public ODBModels.User[] SearchUser(string login, string fullName, string role) {
            return base.Channel.SearchUser(login, fullName, role);
        }
        
        public System.Threading.Tasks.Task<ODBModels.User[]> SearchUserAsync(string login, string fullName, string role) {
            return base.Channel.SearchUserAsync(login, fullName, role);
        }
        
        public ODBModels.User[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ODBModels.User[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void UpdateUser(Models.User user, Models.User newUser) {
            base.Channel.UpdateUser(user, newUser);
        }
        
        public System.Threading.Tasks.Task UpdateUserAsync(Models.User user, Models.User newUser) {
            return base.Channel.UpdateUserAsync(user, newUser);
        }
        
        public void DeleteUser(Models.User user) {
            base.Channel.DeleteUser(user);
        }
        
        public System.Threading.Tasks.Task DeleteUserAsync(Models.User user) {
            return base.Channel.DeleteUserAsync(user);
        }
        
        public Models.User AuthorizationUser(string login, string password) {
            return base.Channel.AuthorizationUser(login, password);
        }
        
        public System.Threading.Tasks.Task<Models.User> AuthorizationUserAsync(string login, string password) {
            return base.Channel.AuthorizationUserAsync(login, password);
        }
        
        public bool ChangePassword(Models.User user, string password) {
            return base.Channel.ChangePassword(user, password);
        }
        
        public System.Threading.Tasks.Task<bool> ChangePasswordAsync(Models.User user, string password) {
            return base.Channel.ChangePasswordAsync(user, password);
        }
        
        public void AddRole(string roleName) {
            base.Channel.AddRole(roleName);
        }
        
        public System.Threading.Tasks.Task AddRoleAsync(string roleName) {
            return base.Channel.AddRoleAsync(roleName);
        }
        
        public Models.Role[] GetAllRoles() {
            return base.Channel.GetAllRoles();
        }
        
        public System.Threading.Tasks.Task<Models.Role[]> GetAllRolesAsync() {
            return base.Channel.GetAllRolesAsync();
        }
    }
}
