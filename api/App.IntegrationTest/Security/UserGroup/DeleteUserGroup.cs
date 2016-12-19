namespace App.IntegrationTest.Security.UserGroup
{
    using System;
    using Common.Http;
    using App.Common.UnitTest;
    using Service.Security;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Collections.Generic;
    using Service.Security.UserGroup;

    [TestClass]
    public class DeleteUserGroup : BaseIntegrationTest
    {
        private readonly CreateUserGroupResponse createdUserGroupResponse;
        public DeleteUserGroup() : base(@"api/usergroups/{0}")
        {
            this.createdUserGroupResponse = this.CreateNewUserGroup();
        }

        private CreateUserGroupResponse CreateNewUserGroup()
        {
            CreateUserGroupRequest createUserGroupRequest = new CreateUserGroupRequest()
            {
                Name = "name of usergroup" + Guid.NewGuid(),
                Description = "description of usergroup",
                PermissionIds = new List<Guid>()
            };

            IResponseData<CreateUserGroupResponse> createUserGroupResponse = this.Connector.Post<CreateUserGroupRequest, CreateUserGroupResponse>(string.Format(this.BaseUrl, string.Empty), createUserGroupRequest);
            return createUserGroupResponse.Data;
        }

        [TestMethod()]
        public void Security_UserGroup_DeleteUserGroup_ShouldBeSuccess_WithValidRequest()
        {
            IResponseData<string> deleteResponse = this.Connector.Delete<string>(string.Format(this.BaseUrl, this.createdUserGroupResponse.Id));
            IResponseData<GetUserGroupResponse> userGroupResponse = this.Connector.Get<GetUserGroupResponse>(string.Format(this.BaseUrl, this.createdUserGroupResponse.Id));
            Assert.IsNull(userGroupResponse.Data);
            Assert.IsTrue(deleteResponse.Errors.Count == 0);
        }

        [TestMethod]
        public void Security_UserGroup_DeleteUserGroup_ShouldGetException_WithEmptyId()
        {
            IResponseData<string> response = this.Connector.Delete<string>(string.Format(this.BaseUrl, Guid.Empty));
            Assert.IsTrue(response.Errors.Count > 0);
            Assert.IsTrue(response.Errors.Any(item => item.Key == "security.userGroups.validation.userGroupIdIsInvalid"));
        }

        [TestMethod]
        public void Security_UserGroup_DeleteUserGroup_ShouldGetException_WithNotExistedId()
        {
            IResponseData<string> createUserGroupResponse = this.Connector.Delete<string>(string.Format(this.BaseUrl, Guid.NewGuid()));
            Assert.IsTrue(createUserGroupResponse.Errors.Count > 0);
            Assert.IsTrue(createUserGroupResponse.Errors.Any(item => item.Key == "security.userGroups.validation.userGroupNotExisted"));
        }
    }
}
