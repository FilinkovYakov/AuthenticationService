using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using IRepository;
using Models;
using Moq;
using AuthenticationService;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestMethod1()
        {
            AuthenticationService.AuthenticationService service = new AuthenticationService.AuthenticationService();

            OperationResult result = service.CreateUser(new User
            {
                Login = "cc",
                FullName = "abc",
                Roles = new List<Role>()
                {
                    new Role("admin")
                }
            }, "password");

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Errors.Contains(OperationError.LoginErr));


        }

        [Test]
        public void TestMethod2()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Create(It.IsAny<ODBModels.User>())).Verifiable();
            userRepositoryMock.Verify(x => x.Create(It.IsAny<ODBModels.User>()), Times.Never);

            userRepositoryMock.Setup(x => x.Delete(It.IsAny<ODBModels.User>())).Verifiable();
            userRepositoryMock.Verify(x => x.Delete(It.IsAny<ODBModels.User>()), Times.Never);

            userRepositoryMock.Setup(x => x.Search("", "", "")).Verifiable();
            userRepositoryMock.Verify(x => x.Search("", "", ""), Times.Never);

            userRepositoryMock.Setup(x => x.Update(It.IsAny<ODBModels.User>())).Verifiable();
            userRepositoryMock.Verify(x => x.Update(It.IsAny<ODBModels.User>()), Times.Never);
        }
    }
}