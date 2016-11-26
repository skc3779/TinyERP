namespace App.IntegrationTest.Security.Permission
{
    using App.Common.Http;
    using App.Service.Security.Permission;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;

    public class CreatePermission : BaseIntegrationTest
    {
        public CreatePermission() : base("permissions")
        {
        }

        [TestMethod()]
        public void Security_Permission_CreatePermission_ShouldBeSuccess_WithValidRequest()
        {
            CreatePermissionRequest request = new CreatePermissionRequest("Name " + Guid.NewGuid(), "Key " + Guid.NewGuid(), "desc");
            IResponseData<CreatePermissionResponse> response = this.Connector.Post(this.BaseUrl, request);
            Assert.IsTrue(response.Status == HttpStatusCode.OK);
            Assert.IsTrue(response.Errors.Count == 0);
            Assert.IsTrue(response.Data != null);
            Assert.IsTrue(response.Data.Id != null && response.Data.Id != Guid.Empty);
        }
    }
}
