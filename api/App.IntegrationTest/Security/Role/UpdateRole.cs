namespace App.IntegrationTest.Security.Role
{
    using App.Common.UnitTest;
    using Common.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Security.Role;
    using System;
    using System.Linq;

    [TestClass]
    public class UpdateRole : BaseIntegrationTest
    {
        private readonly CreateRoleResponse createdRoleResponse;
        public UpdateRole() : base(@"api/roles/{0}")
        {
            createdRoleResponse = this.CreateNewRole();
        }

        [TestMethod()]
        public void Security_Role_UpdateRole_ShouldBeSuccess_WithValidRequest()
        {
            UpdateRoleRequest request = new UpdateRoleRequest(this.createdRoleResponse.Id, "new updated name" + Guid.NewGuid(), "desc");
            IResponseData<string> response = this.Connector.Put<UpdateRoleRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count == 0);
        }

        [TestMethod()]
        public void Security_Role_UpdateRole_ShouldThrowException_WithEmptyName()
        {
            UpdateRoleRequest request = new UpdateRoleRequest(this.createdRoleResponse.Id, string.Empty, "desc");
            IResponseData<string> response = this.Connector.Put<UpdateRoleRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateRole.validation.nameIsRequired"));
        }

        [TestMethod()]
        public void Security_Role_UpdateRole_ShouldThrowException_WithNotExistedId()
        {
            UpdateRoleRequest request = new UpdateRoleRequest(Guid.NewGuid(), string.Empty, "desc");
            IResponseData<string> response = this.Connector.Put<UpdateRoleRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.roles.validation.roleNotExisted"));
        }

        [TestMethod()]
        public void Security_Role_UpdateRole_ShouldThrowException_WithEmptyId()
        {
            UpdateRoleRequest request = new UpdateRoleRequest(Guid.Empty, string.Empty, "desc");
            IResponseData<string> response = this.Connector.Put<UpdateRoleRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.roles.validation.idIsInvalid"));
        }

        private CreateRoleResponse CreateNewRole()
        {
            CreateRoleRequest request = new CreateRoleRequest("update role name" + Guid.NewGuid(), "desc");
            IResponseData<CreateRoleResponse> response = this.Connector.Post<CreateRoleRequest, CreateRoleResponse>(string.Format(this.BaseUrl, string.Empty), request);
            return response.Data;
        }
    }
}
