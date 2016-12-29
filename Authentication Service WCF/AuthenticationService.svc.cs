using InternshipAuthenticationService.Repository;
using InternshipAuthenticationService.Models.OperationResult;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using AutoMapper;
using Microsoft.Practices.Unity;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using log4net;
using log4net.Config;

namespace InternshipAuthenticationService.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService, IServiceBehavior
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        static AuthenticationService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.ServiceModels.Role, Models.EFModels.Role>()
                .ForMember<IList<Models.EFModels.User>>(x => x.Users, opt => opt.Ignore());

                cfg.CreateMap<Models.EFModels.Role, Models.ServiceModels.Role>();

                cfg.CreateMap<Models.ServiceModels.User, Models.EFModels.User>()
                .ForMember<string>(x => x.Password, opt => opt.Ignore())
                .ForMember<string>(x => x.Salt, opt => opt.Ignore());

                cfg.CreateMap<Models.EFModels.User, Models.ServiceModels.User>();

            });
            
            
        }

        public AuthenticationService()
            : this(DependencyContainer.Container.Resolve<IUserRepository>(), DependencyContainer.Container.Resolve<IRoleRepository>())
        {
        }

        public AuthenticationService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public OperationResult AddRole(string roleName)
        {
            OperationResult res = new OperationResult();
            if (string.IsNullOrEmpty(roleName))
                res.AddResultCode(OperationErrors.RoleErr);
            if (res.Success)
            {
                Models.EFModels.Role newRole = new Models.EFModels.Role(roleName);
                _roleRepository.Create(newRole);
            }
            return res;
        }

        public IEnumerable<Models.ServiceModels.Role> GetAllRoles()
        {
            return  Mapper.Map<List<Models.ServiceModels.Role>>(_roleRepository.GetAll()).ToList();
        }

        public OperationResult<Models.ServiceModels.User> AuthorizationUser(string login, string password)
        {
            OperationResult<Models.ServiceModels.User> res = new OperationResult<Models.ServiceModels.User>();
            Models.EFModels.User user = _userRepository.GetByLogin(login);
            if (user == null)
            {
                res.AddResultCode(OperationErrors.AutorizationFiledErr);
            }
            else
            {
                Models.ServiceModels.User newUser = Mapper.Map<Models.EFModels.User, Models.ServiceModels.User>(user);
                if (!user.Password.Equals(CryptoFunctions.GetMd5Hash(password, user.Salt)))
                    res.AddResultCode(OperationErrors.AutorizationFiledErr);
                else
                    res.Result = newUser;
            }
            return res;
        }

        public OperationResult ChangePassword(Models.ServiceModels.User user, string password)
        {
            OperationResult res = new OperationResult();
            if (string.IsNullOrEmpty(password))
            {
                res.AddResultCode(OperationErrors.PassErr);
            }
            if (user == null)
            {
                res.AddResultCode(OperationErrors.NullErr);
            }
            else
            {
                if (!IsExistsById(user.Id))
                {
                    res.AddResultCode(OperationErrors.UserNotExistErr);
                }
            }
            if (res.Success)
            {
                string salt = CryptoFunctions.GenerationSalt(32);
                string passwordHash = CryptoFunctions.GetMd5Hash(password, salt);
                Models.EFModels.User newUser = Mapper.Map<Models.EFModels.User>(user);
                newUser.Password = passwordHash;
                newUser.Salt = salt;
                _userRepository.ChangePassword(newUser);
            }
            return res;
        }

        public OperationResult CreateUser(Models.ServiceModels.User user, string password)
        {
            OperationResult res = new OperationResult();
            if (string.IsNullOrEmpty(password))
            {
                res.AddResultCode(OperationErrors.PassErr);
            }
            if (user == null)
            {
                res.AddResultCode(OperationErrors.NullErr);
            }
            else
            {
                if (string.IsNullOrEmpty(user.Login))
                {
                    res.AddResultCode(OperationErrors.LoginErr);
                }
                if (string.IsNullOrEmpty(user.FullName))
                {
                    res.AddResultCode(OperationErrors.FullNameErr);
                }
                if (string.IsNullOrEmpty(user.Roles.First().RoleName))
                {
                    res.AddResultCode(OperationErrors.RoleErr);
                }
                if (IsExists(user))
                {
                    res.AddResultCode(OperationErrors.UserExistErr);
                }
            }
            if (res.Success)
            {
                string salt = CryptoFunctions.GenerationSalt(32);
                string passwordHash = CryptoFunctions.GetMd5Hash(password, salt);

                Models.EFModels.User newUser = Mapper.Map<Models.ServiceModels.User, Models.EFModels.User>(user);
                newUser.Password = passwordHash;
                newUser.Salt = salt;
                _userRepository.Create(newUser);
            }
            return res;
        }

        public OperationResult DeleteUser(Models.ServiceModels.User user)
        {
            OperationResult res = new OperationResult();
            if (user == null)
            {
                res.AddResultCode(OperationErrors.NullErr);
            }
            else
            {
                if (!IsExistsById(user.Id))
                    res.AddResultCode(OperationErrors.UserNotExistErr);
            }
            if (res.Success)
            {
                Models.EFModels.User newUser = Mapper.Map<Models.ServiceModels.User, Models.EFModels.User>(user);
                _userRepository.Delete(newUser);
            }
            return res;          
        }

        public OperationResult UpdateUser(Models.ServiceModels.User user)
        {
            OperationResult res = new OperationResult();
            if (user == null)
            {
                res.AddResultCode(OperationErrors.NullErr);
            }
            else
            {
                if (string.IsNullOrEmpty(user.Login))
                {
                    res.AddResultCode(OperationErrors.LoginErr);
                }
                if (string.IsNullOrEmpty(user.FullName))
                {
                    res.AddResultCode(OperationErrors.FullNameErr);
                }
                if (string.IsNullOrEmpty(user.Roles.First().RoleName))
                {
                    res.AddResultCode(OperationErrors.RoleErr);
                }
                if (!IsExistsById(user.Id))
                    res.AddResultCode(OperationErrors.UserNotExistErr);
                if (IsExistsLogin(user))
                    res.AddResultCode(OperationErrors.UserExistErr);
            }
            if (res.Success)
            {
                Models.EFModels.User newUser = Mapper.Map<Models.EFModels.User>(user);
                _userRepository.Update(newUser);
            }
            return res;
        }

        public IEnumerable<Models.ServiceModels.User> SearchUser(string login, string fullName, string role)
        {
            IEnumerable<Models.EFModels.User> users;
            users = _userRepository.Search(login, fullName, role);          
            return Mapper.Map<IEnumerable<Models.ServiceModels.User>>(users).ToList();
        }

        public IEnumerable<Models.ServiceModels.User> GetAll()
        {          
            return Mapper.Map<List<Models.ServiceModels.User>>(_userRepository.GetAll()).ToList();
        }

        private bool IsExists(Models.ServiceModels.User user)
        {
            return _userRepository.GetByLogin(user.Login) != null;
        }

        private bool IsExistsLogin(Models.ServiceModels.User user)
        {
            if (_userRepository.GetByLogin(user.Login) != null)
                return _userRepository.GetByLogin(user.Login).Id != user.Id;
            return false;
        }

        private bool IsExistsById(int id)
        {
            return _userRepository.GetById(id) != null;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            ILog log;
            XmlConfigurator.Configure();
            log = LogManager.GetLogger(typeof(AuthenticationService));
            IErrorHandler handler = new CustomErrorHandler(log);
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(handler);
            }
        }
    }
}
