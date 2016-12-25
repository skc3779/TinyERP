namespace App.Test.Security.UserGroup
{
    using App.Common.DI;
    using App.Common.UnitTest;
    using App.Common.Validation;
    using App.Service.Security;
    using App.Service.Security.UserGroup;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class UpdateUserGroupTest : BaseUnitTest
    {
        private CreateUserGroupResponse userGroup;
        private CreateUserGroupResponse userGroup1;
        protected override void OnInit()
        {
            base.OnInit();
            string name = "Name of User Group" + Guid.NewGuid();
            string key = "Key of User Group" + Guid.NewGuid();
            string desc = "Desc of User Group";
            this.userGroup = this.CreateUserGroupItem(name, key, desc);

            name = "Duplicated Name" + Guid.NewGuid();
            key = "Duplicated key" + Guid.NewGuid();
            desc = "Desc of User Group";
            this.userGroup1 = this.CreateUserGroupItem(name, key, desc);
        }

        private CreateUserGroupResponse CreateUserGroupItem(string name, string key, string desc)
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest(name, key, desc);
            IUserGroupService service = IoC.Container.Resolve<IUserGroupService>();
            return service.Create(request);
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldBeSuccess_WithValidRequest()
        {
            string name = "New Name of User Group" + Guid.NewGuid();
            string key = "New Key of User Group" + Guid.NewGuid();
            string desc = "New Desc of User Group";
            this.UpdateUserGroupItem(this.userGroup.Id, name, key, desc);

            IUserGroupService service = IoC.Container.Resolve<IUserGroupService>();
            App.Service.Security.UserGroup.GetUserGroupResponse updatedUserGroup = service.Get(this.userGroup.Id);
            Assert.AreEqual(updatedUserGroup.Name, name);
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldGetException_WithEmptyName()
        {
            try
            {
                string name = string.Empty;
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.UpdateUserGroupItem(this.userGroup.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.nameIsRequire"));
            }
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldGetException_WithEmptyId()
        {
            try
            {
                string name = this.userGroup1.Name;
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.UpdateUserGroupItem(Guid.Empty, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.idIsInvalid"));
            }
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldGetException_WithNotExistedId()
        {
            try
            {
                string name = this.userGroup1.Name;
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.UpdateUserGroupItem(Guid.NewGuid(), name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.itemNotExist"));
            }
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldGetException_WithDuplicatedName()
        {
            try
            {
                string name = this.userGroup1.Name;
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.UpdateUserGroupItem(this.userGroup.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.nameAlreadyExist"));
            }
        }

        [TestMethod]
        public void Security_UserGroup_UpdateUserGroup_ShouldGetException_WithDuplicatedKey()
        {
            try
            {
                string name = this.userGroup1.Name;
                string key = "Key of User Group" + Guid.NewGuid();
                string desc = "Desc of User Group";
                this.UpdateUserGroupItem(this.userGroup.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateUserGroup.validation.keyAlreadyExisted"));
            }
        }

        private void UpdateUserGroupItem(Guid id, string name, string key, string desc)
        {
            UpdateUserGroupRequest request = new UpdateUserGroupRequest(id, name, key, desc);
            IUserGroupService service = IoC.Container.Resolve<IUserGroupService>();
            service.Update(request);
        }
    }
}
