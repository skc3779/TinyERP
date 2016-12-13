namespace App.IntegrationTest.Security.Role
{
    using App.Common.UnitTest;
    using Common.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Security.Role;
    using System;
    using System.Linq;

    [TestClass]
    public class CreateRole : BaseIntegrationTest
    {
        public CreateRole() : base(@"api/roles")
        {
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldBeSuccess_WithValidRequest()
        {
            CreateRoleRequest request = new CreateRoleRequest("Name of Role " + Guid.NewGuid().ToString("N"), "desc");
            IResponseData<CreateRoleResponse> response = this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count == 0);
            Assert.IsTrue(response.Data != null);
            Assert.IsTrue(response.Data.Id != null && response.Data.Id != Guid.Empty);
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldThrowException_WithEmptyName()
        {
            CreateRoleRequest request = new CreateRoleRequest(string.Empty, "desc");
            IResponseData<CreateRoleResponse> response = this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateRole.validation.nameIsRequired"));
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldThrowException_WithDuplicatedName()
        {
            CreateRoleRequest request = new CreateRoleRequest("Name of Role " + Guid.NewGuid().ToString("N"), "desc");
            this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request);
            IResponseData<CreateRoleResponse> response = this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateRole.validation.nameAlreadyExisted"));
        }

        [TestMethod()]
        public void Security_Permission_CreatePermission_ShouldThroException_WithDuplicatedKey()
        {
            string newGuiId = Guid.NewGuid().ToString("N");
            string name = "Name of Role" + newGuiId;
            string name1 = "Name_of_Role" + newGuiId;
            CreateRoleRequest request = new CreateRoleRequest(name, "desc");
            CreateRoleRequest request1 = new CreateRoleRequest(name1, "desc");
            this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request);
            IResponseData<CreateRoleResponse> response = this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(this.BaseUrl, request1);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateRole.validation.keyAlreadyExisted"));
        }
    }
}
