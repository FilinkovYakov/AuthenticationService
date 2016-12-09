using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using InternshipAuthenticationService.Repository;
using InternshipAuthenticationService.Models.EFModels;
using InternshipAuthenticationService.Models.ServiceModels;
using InternshipAuthenticationService.Models.OperationResult;
using Moq;
using InternshipAuthenticationService.AuthenticationService;
using InternshipAuthenticationService.DAL;
using Microsoft.Practices.Unity;

namespace InternshipAuthenticationService.UnitTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test]
        public void CreateUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(new Models.ServiceModels.User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
                {
                    new Models.ServiceModels.Role("Admin"),
                    new Models.ServiceModels.Role("Intern")
                }
            }, "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors, Is.Empty);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Once);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CreateUserInvalidUser()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(null, null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.NullErr), Is.True);
            Assert.That(result.Errors.Contains(OperationErrors.PassErr), Is.True);
            Assert.That(result.Errors.Count() == 2, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CreateUserInvalidLoginTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(new Models.ServiceModels.User
            {
                Login = "",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            }, "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.LoginErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CreateUserInvalidFullNameTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            }, "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.FullNameErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CreateUserInvalidRoleTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "ivan",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("")
            }
            }, "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.RoleErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
        }

        [Test]
        public void CreateUserInvalidPasswordTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "ivan",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            }, "");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.PassErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CreateUserExistTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Returns(new Models.EFModels.User()).Verifiable();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.User>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.CreateUser(new Models.ServiceModels.User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
                {
                    new Models.ServiceModels.Role("Admin"),
                    new Models.ServiceModels.Role("Intern")
                }
            }, "password");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.UserExistErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
        }





        [Test]
        public void SearchUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Search(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<Models.EFModels.User>() { new Models.EFModels.User ()}).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());                   
            service.SearchUser("", "", "");
            userRepositoryMock.Verify(x => x.Search(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);           
        }





        [Test]
        public void EditUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Models.EFModels.User()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.UpdateUser(new Models.ServiceModels.User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
                {
                    new Models.ServiceModels.Role("Admin")
                }
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors.Count() == 0, Is.True);
            userRepositoryMock.Verify(x => x.Update(It.IsAny<Models.EFModels.User>()), Times.Once);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void EditUserInvalidUser()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.UpdateUser(null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.NullErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void EditUserInvalidLoginTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Models.EFModels.User()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.UpdateUser(new Models.ServiceModels.User
            {
                Login = "",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.LoginErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void EditUserInvalidFullNameTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Models.EFModels.User()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.UpdateUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            });

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.FullNameErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void EditUserInvalidRoleTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Models.EFModels.User()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.UpdateUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "ivan",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("")
            }
            });

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.RoleErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void EditUserNotExistUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.UpdateUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "ivan",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.UserNotExistErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }




        [Test]
        public void DeleteUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Delete(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Models.EFModels.User()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.DeleteUser(new Models.ServiceModels.User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
                {
                    new Models.ServiceModels.Role("Admin")
                }
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors.Count() == 0, Is.True);
            userRepositoryMock.Verify(x => x.Delete(It.IsAny<Models.EFModels.User>()), Times.Once);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void DeleteUserInvalidUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Delete(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.DeleteUser(new Models.ServiceModels.User
            {
                Login = "login",
                FullName = "ivan",
                Roles = new List<Models.ServiceModels.Role>()
            {
                new Models.ServiceModels.Role("Admin")
            }
            });
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.UserNotExistErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Delete(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void DeleteUserNotExistUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Delete(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.DeleteUser(null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.NullErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Delete(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
        }




        [Test]
        public void ChangeUserPasswordTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Models.EFModels.User()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.ChangePassword(new Models.ServiceModels.User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
                {
                    new Models.ServiceModels.Role("Admin"),
                    new Models.ServiceModels.Role("Intern")
                }
            }, "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors.Count() == 0, Is.True);
            userRepositoryMock.Verify(x => x.Update(It.IsAny<Models.EFModels.User>()), Times.Once);
            //userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ChangeUserPasswordInvalidUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.ChangePassword(null, null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.NullErr), Is.True);
            Assert.That(result.Errors.Contains(OperationErrors.PassErr), Is.True);
            Assert.That(result.Errors.Count() == 2, Is.True);
            userRepositoryMock.Verify(x => x.Update(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void ChangeUserPasswordUserNotExistTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Update(It.IsAny<Models.EFModels.User>())).Verifiable();
            userRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.ChangePassword(new Models.ServiceModels.User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Models.ServiceModels.Role>()
                {
                    new Models.ServiceModels.Role("Admin"),
                    new Models.ServiceModels.Role("Intern")
                }
            }, "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors.Contains(OperationErrors.UserNotExistErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.Update(It.IsAny<Models.EFModels.User>()), Times.Never);
            userRepositoryMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }





        [Test]
        public void AutherizationUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Returns(new Models.EFModels.User
            {
                Password = "Ip7reF5lLCwFJtfCUW64zQ==",
                Salt = "aMZ1Eh+6K6Eh4sK87E0ZVEG8jA9rnFn88r4Pm5MYtnA="
                
            }).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult<Models.ServiceModels.User>  result = service.AuthorizationUser("login", "z");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors, Is.Empty);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AutherizationUserInvalidUserTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult result = service.AuthorizationUser(null, null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.AutorizationFiledErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AutherizationUserInvalidPasswordTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetByLogin(It.IsAny<string>())).Returns(new Models.EFModels.User
            {
                Password = "Ip7reF5lLCwFJtfCUW64zQ==",
                Salt = "aMZ1Eh+6K6Eh4sK87E0ZVEG8jA9rnFn88r4Pm5MYtnA="

            }).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            OperationResult<Models.ServiceModels.User> result = service.AuthorizationUser("login", "password");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result, Is.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.AutorizationFiledErr), Is.True);
            Assert.That(result.Errors.Count() == 1, Is.True);
            userRepositoryMock.Verify(x => x.GetByLogin(It.IsAny<string>()), Times.Once);
        }




        [Test]
        public void GetAllUsersTest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetAll()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(userRepositoryMock.Object, Mock.Of<IRoleRepository>());
            service.GetAll();        
            userRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }




        [Test]
        public void AddRoleTest()
        {
            Mock<IRoleRepository> roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.Role>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(Mock.Of<IUserRepository>(), roleRepositoryMock.Object);
            OperationResult result = service.AddRole("role");
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.True);
            Assert.That(result.Errors, Is.Empty);
            roleRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.Role>()), Times.Once);
        }

        [Test]
        public void AddRoleInvalidRoleNameTest()
        {
            Mock<IRoleRepository> roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(x => x.Create(It.IsAny<Models.EFModels.Role>())).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(Mock.Of<IUserRepository>(), roleRepositoryMock.Object);
            OperationResult result = service.AddRole(null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors.Contains(OperationErrors.RoleErr), Is.True);
            roleRepositoryMock.Verify(x => x.Create(It.IsAny<Models.EFModels.Role>()), Times.Never);
        }

        [Test]
        public void GetAllRolesTest()
        {
            Mock<IRoleRepository> roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(x => x.GetAll()).Verifiable();
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService(Mock.Of<IUserRepository>(), roleRepositoryMock.Object);
            service.GetAllRoles();
            roleRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}