namespace App.Service.Test.Security.Permission
{
    using App.Common.DI;
    using App.Common.UnitTest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Security;
    using Service.Security.Permission;

    [TestClass]
    public class CreatePermissionShouldBe : BaseUnitTest
    {
        [TestInitialize()]
        public void Init()
        {
            this.Application.OnApplicationStarted();
        }

        [TestCleanup()]
        public void Finished()
        {
            this.Application.OnApplicationEnded();
        }

        [TestMethod]
        public void WithValidRequest()
        {
            CreatePermissionRequest request = new CreatePermissionRequest() { Name = "Test name", Key = "test key", Description = "test desc" };
            IPermissionService service = IoC.Container.Resolve<IPermissionService>();
            App.Entity.Security.Permission permission = service.Create(request);
            Assert.IsNotNull(permission);
        }
    }
}
