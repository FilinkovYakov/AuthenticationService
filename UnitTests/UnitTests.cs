using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using IRepository;
using Models;
using Moq;
using AuthenticationService;
using DAL;
using Microsoft.Practices.Unity;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void CreateUserTest()
        {
            using (var lifeManager = new ScopedLifetimeManager())
            {
                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();

                DependencyContainer.Container.RegisterInstance<IUserRepository>(userRepositoryMock.Object, lifeManager);

                AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();
                OperationResult result = service.CreateUser(new User
                {
                    Login = "cc",
                    FullName = "abc",
                    Roles = new List<Role>()
                {
                    new Role("Admin")
                }
                }, "password");

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.True);
                Assert.That(result.Errors, Is.Empty);

                userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Once);
            }
        }

        [Test]
        public void CreateUserInvalidLoginTest()
        {
            using (var lifeManager = new ScopedLifetimeManager())
            {
                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();

                DependencyContainer.Container.RegisterInstance<IUserRepository>(userRepositoryMock.Object, lifeManager);

                AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();
                OperationResult result = service.CreateUser(new User
                {
                    Login = "",
                    FullName = "abc",
                    Roles = new List<Role>()
                {
                    new Role("Admin")
                }
                }, "password");

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors.Contains(OperationError.LoginErr), Is.True);

                userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Never);
            }
        }

        [Test]
        public void CreateUserInvalidFullNameTest()
        {
            using (var lifeManager = new ScopedLifetimeManager())
            {
                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();

                DependencyContainer.Container.RegisterInstance<IUserRepository>(userRepositoryMock.Object, lifeManager);

                AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();
                OperationResult result = service.CreateUser(new User
                {
                    Login = "login",
                    FullName = "",
                    Roles = new List<Role>()
                {
                    new Role("Admin")
                }
                }, "password");

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors.Contains(OperationError.FullNameErr), Is.True);

                userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Never);
            }
        }

        [Test]
        public void CreateUserInvalidRoleTest()
        {
            using (var lifeManager = new ScopedLifetimeManager())
            {
                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();

                DependencyContainer.Container.RegisterInstance<IUserRepository>(userRepositoryMock.Object, lifeManager);

                AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();
                OperationResult result = service.CreateUser(new User
                {
                    Login = "login",
                    FullName = "ivan",
                    Roles = new List<Role>()
                {
                    new Role("")
                }
                }, "password");

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors.Contains(OperationError.RoleErr), Is.True);

                userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Never);
            }
        }

        [Test]
        public void CreateUserInvalidPasswordTest()
        {
            using (var lifeManager = new ScopedLifetimeManager())
            {
                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();

                DependencyContainer.Container.RegisterInstance<IUserRepository>(userRepositoryMock.Object, lifeManager);

                AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();
                OperationResult result = service.CreateUser(new User
                {
                    Login = "login",
                    FullName = "ivan",
                    Roles = new List<Role>()
                {
                    new Role("Admin")
                }
                }, "");

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors.Contains(OperationError.PassErr), Is.True);

                userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Never);
            }
        }

        [Test]
        public void CreateUserInvalidExistUserTest()
        {
            using (var lifeManager = new ScopedLifetimeManager())
            {
                User user = new User
                {
                    Login = "login",
                    FullName = "",
                    Roles = new List<Role>()
                    {
                        new Role("Admin")
                    }
                };
                Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
                userRepositoryMock
                    .Setup(x => x.GetByLogin(user.Login))
                    .Returns(new ODBModels.User())
                    .Verifiable();
                userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();

                DependencyContainer.Container.RegisterInstance<IUserRepository>(userRepositoryMock.Object, lifeManager);

                AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();
                OperationResult result = service.CreateUser(user, "password");

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors.Contains(OperationError.UserExistsErr), Is.True);

                userRepositoryMock.Verify(x => x.GetByLogin(user.Login), Times.Once);
                userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Never);
            }
        }
    }
}