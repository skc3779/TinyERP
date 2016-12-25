namespace App.Test.Security.UserGroup
{
    using App.Common.DI;
    using App.Common.UnitTest;
    using App.Common.Validation;
    using App.Service.Security;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class CreateUserGroupTest : BaseUnitTest
    {
        [TestMethod]
        public void Security_UserGroup_CreateUserGroup_ShouldBeSuccess_WithValidRequest()
        {
            string name = "Name of User Group" + Guid.NewGuid();
            string key = "Key of User Group" + Guid.NewGuid();
            string desc = "Desc of User Group";
            CreateUserGroupResponse userGroup = this.CreateUserGroupItem(name, key, desc);
            Assert.IsNotNull(userGroup);
        }

        [TestMethod]
        public void Security_UserGroup_CreateUserGroup_ShouldGetException_WithEmptyName()
        {
            try
            {
                string name = string.Empty;
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.CreateUserGroupItem(name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.nameIsRequire"));
            }
        }

        [TestMethod]
        public void Security_UserGroup_CreateUserGroup_ShouldGetException_WithDuplicatedName()
        {
            try
            {
                string name = "Duplicated Name" + Guid.NewGuid();
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.CreateUserGroupItem(name, key, desc);
                this.CreateUserGroupItem(name, Guid.NewGuid().ToString(), desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.nameAlreadyExist"));
            }
        }

        private CreateUserGroupResponse CreateUserGroupItem(string name, string key, string desc)
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest(name, key, desc);
            IUserGroupService service = IoC.Container.Resolve<IUserGroupService>();
            return service.Create(request);
        }
    }
}
