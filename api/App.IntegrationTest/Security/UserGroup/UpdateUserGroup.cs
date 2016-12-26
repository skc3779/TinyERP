namespace App.IntegrationTest.Security.UserGroup
{
    using Common.Http;
    using Common.UnitTest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Service.Security.UserGroup;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class UpdateUserGroup : BaseIntegrationTest
    {
        private readonly CreateUserGroupResponse userGroupResponse;
        private readonly CreateUserGroupResponse userGroupResponse1;
        public UpdateUserGroup() : base(@"api/usergroups/{0}")
        {
            this.userGroupResponse = this.CreateUserGroupItem();
            this.userGroupResponse1 = this.CreateUserGroupItem();
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldBeSuccess_WithValidRequest()
        {
            UpdateUserGroupRequest request = new UpdateUserGroupRequest()
            {
                Id = this.userGroupResponse.Id,
                Name = "update Name of UserGroup" + Guid.NewGuid(),
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<string> response = this.Connector.Put<UpdateUserGroupRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count == 0);
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldThrowException_WithEmptyName()
        {
            UpdateUserGroupRequest request = new UpdateUserGroupRequest()
            {
                Id = this.userGroupResponse.Id,
                Name = string.Empty,
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<string> response = this.Connector.Put<UpdateUserGroupRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.nameIsRequire"));
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldThrowException_WithEmptyId()
        {
            UpdateUserGroupRequest request = new UpdateUserGroupRequest()
            {
                Id = Guid.Empty,
                Name = string.Empty,
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<string> response = this.Connector.Put<UpdateUserGroupRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.idIsInvalid"));
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldThrowException_WithNotExtistedId()
        {
            UpdateUserGroupRequest request = new UpdateUserGroupRequest()
            {
                Id = Guid.NewGuid(),
                Name = string.Empty,
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<string> response = this.Connector.Put<UpdateUserGroupRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.itemNotExist"));
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldThrowException_WithDuplicateddNameAndKey()
        {
            UpdateUserGroupRequest request = new UpdateUserGroupRequest()
            {
                Id = this.userGroupResponse.Id,
                Name = this.userGroupResponse1.Name,
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<string> response = this.Connector.Put<UpdateUserGroupRequest, string>(string.Format(this.BaseUrl, request.Id), request);
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.nameAlreadyExist"));
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.addOrUpdateUserGroup.validation.keyAlreadyExisted"));
        }

        private CreateUserGroupResponse CreateUserGroupItem()
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest()
            {
                Name = "name of UserGroup" + Guid.NewGuid(),
                Description = "description of UserGroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<CreateUserGroupResponse> response = this.Connector.Post<CreateUserGroupRequest, CreateUserGroupResponse>(string.Format(this.BaseUrl, string.Empty), request);
            return response.Data;
        }
    }
}
