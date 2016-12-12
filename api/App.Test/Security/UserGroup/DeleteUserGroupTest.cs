namespace App.Test.Security.UserGroup
{
    using System;
    using System.Collections.Generic;
    using Service.Security;
    using Common.UnitTest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Common.DI;
    using Service.Security.UserGroup;
    using Common.Validation;

    [TestClass]
    public class DeleteUserGroupTest : BaseUnitTest
    {
        [TestMethod]
        public void Security_UserGroup_DeleteUserGroup_ShouldBeSuccess_WithValidRequest()
        {
            string name = "name of role" + Guid.NewGuid();
            string description = "desc of role";
            IList<Guid> permissionIds = new List<Guid>();
            CreateUserGroupResponse createUserGroupResponse = this.CreateUserGroup(name, description, permissionIds);
            IUserGroupService userGroupService = IoC.Container.Resolve<IUserGroupService>();
            userGroupService.Delete(createUserGroupResponse.Id);
            GetUserGroupResponse userGroupRespone = userGroupService.Get(createUserGroupResponse.Id);
            Assert.IsNull(userGroupRespone);
        }

        [TestMethod]
        public void Security_UserGroup_DeleteUserGroup_ShouldGetException_WithNotExistedId()
        {
            try
            {
                Guid userGroupId = Guid.NewGuid();
                this.DeleteUserGroup(userGroupId);
                Assert.IsTrue(false);
            }
            catch (ValidationException exception)
            {
                Assert.IsTrue(exception.HasExceptionKey("security.userGroups.validation.userGroupNotExist"));
            }
        }

        [TestMethod]
        public void Security_UserGroup_DeleteUserGroup_ShouldGetException_WithEmptyId() {
            try
            {
                Guid userGroupId = Guid.Empty;
                this.DeleteUserGroup(userGroupId);
                Assert.IsTrue(false);
            }
            catch (ValidationException exception)
            {
                Assert.IsTrue(exception.HasExceptionKey("security.userGroups.validation.idIsInvalid"));
            }
        }

        private CreateUserGroupResponse CreateUserGroup(string name, string description, IList<Guid> permissions)
        {
            CreateUserGroupRequest createUserGroupRequest = new CreateUserGroupRequest()
            {
                Name = name,
                Description = description,
                PermissionIds = permissions
            };

            IUserGroupService userGroupService = IoC.Container.Resolve<IUserGroupService>();
            return userGroupService.Create(createUserGroupRequest);
        }

        private void DeleteUserGroup(Guid id)
        {
            IUserGroupService userGroupService = IoC.Container.Resolve<IUserGroupService>();
            userGroupService.Delete(id);
        }
    }
}
