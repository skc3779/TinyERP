namespace App.IntegrationTest.Security.Role
{
    using App.Common.UnitTest;
    using Common.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Security;
    using System;

    [TestClass]
    public class CreateRole : BaseIntegrationTest
    {
        public CreateRole() : base(@"api/roles")
        {
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldBeSuccess_WithValidRequest()
        {
            CreateRoleRequest request = new CreateRoleRequest(Guid.NewGuid().ToString("N"), "desc");
            IResponseData<CreateRoleResponse> response = this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count == 0);
            Assert.IsTrue(response.Data != null);
            Assert.IsTrue(response.Data.Id != null && response.Data.Id != Guid.Empty);
        }
    }
}
