namespace App.IntegrationTest.Security.UserGroup
{
    using Common.UnitTest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using App.Service.Security.UserGroup;
    using System;
    using Common.Http;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CreateUserGroup : BaseIntegrationTest
    {
        public CreateUserGroup() : base(@"api/usergroups")
        {
        }

        [TestMethod]
        public void Security_UserGroup_CreateUserGroup_ShouldBeSuccess_WithValidRequest()
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest()
            {
                Name = "name of UserGroup" + Guid.NewGuid(),
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };
            IResponseData<CreateUserGroupResponse> response = this.Connector.Post<CreateUserGroupRequest, CreateUserGroupResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count == 0);
            Assert.IsTrue(response.Data != null);
            Assert.IsTrue(response.Data.Id != null && response.Data.Id != Guid.Empty);
        }

        [TestMethod]
        public void Security_UserGroup_CreateUserGroup_ShouldThrowException_WithEmptyName()
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest()
            {
                Name = string.Empty,
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };
            IResponseData<CreateUserGroupResponse> response = this.Connector.Post<CreateUserGroupRequest, CreateUserGroupResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.nameIsRequire"));
        }

        [TestMethod]
        public void Security_UserGroup_CreateUserGroup_ShouldThrowException_WithDuplicatedNameAndKey()
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest()
            {
                Name = "UserGroup" + Guid.NewGuid().ToString("N"),
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };
            this.Connector.Post<CreateUserGroupRequest, CreateUserGroupResponse>(this.BaseUrl, request);
            IResponseData<CreateUserGroupResponse> response = this.Connector.Post<CreateUserGroupRequest, CreateUserGroupResponse>(this.BaseUrl, request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.nameAlreadyExist"));
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.keyAlreadyExisted"));
        }
    }
}
