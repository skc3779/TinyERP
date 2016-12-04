namespace App.Test.Security.Role
{
    using App.Common.DI;
    using App.Common.UnitTest;
    using App.Common.Validation;
    using App.Service.Security.Role;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class UpdateRoleTest : BaseUnitTest
    {
        private CreateRoleResponse role;
        private CreateRoleResponse role1;
        protected override void OnInit()
        {
            base.OnInit();
            string name = "Name of Role" + Guid.NewGuid();
            string key = "Key of Role" + Guid.NewGuid();
            string desc = "Desc of Role";
            this.role = this.CreateRoleItem(name, key, desc);
            name = "Duplicated Name" + Guid.NewGuid();
            key = "Duplicated key" + Guid.NewGuid();
            desc = "Desc of Permission";
            this.role1 = this.CreateRoleItem(name, key, desc);
        }

        [TestMethod]
        public void Security_Role_UpdateRole_ShouldBeSuccess_WithValidRequest()
        {
            string name = "New Name of Role" + Guid.NewGuid();
            string key = "New Key of Role" + Guid.NewGuid();
            string desc = "New Desc of Role";
            this.UpdateRoleItem(this.role.Id, name, key, desc);
            IRoleService service = IoC.Container.Resolve<IRoleService>();
            App.Service.Security.Role.GetRoleResponse updatedRole = service.GetRole(this.role.Id);
            Assert.AreEqual(updatedRole.Name, name);
        }

        [TestMethod]
        public void Security_Role_UpdateRole_ShouldGetException_WithEmptyName()
        {
            try
            {
                string name = string.Empty;
                string key = "Key of Role" + Guid.NewGuid();
                string desc = "Desc of Role";
                this.UpdateRoleItem(this.role.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.nameIsRequire"));
            }
        }

        [TestMethod]
        public void Security_Permission_UpdateRole_ShouldGetException_WithDuplicatedName()
        {
            try
            {
                string name = this.role1.Name;
                string key = "Key of Role" + Guid.NewGuid();
                string desc = "Desc of Role";
                this.UpdateRoleItem(this.role.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.nameAlreadyExist"));
            }
        }

        [TestMethod]
        public void Security_Role_UpdateRole_ShouldGetException_WithEmptyKey()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid();
                string key = string.Empty;
                string desc = "Desc of Role";
                this.UpdateRoleItem(this.role.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.keyIsRequire"));
            }
        }

        [TestMethod]
        public void Security_Permission_UpdateRole_ShouldGetException_WithDuplicatedKey()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid();
                string key = this.role1.Key;
                string desc = "Desc of Role";
                this.UpdateRoleItem(this.role.Id, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.keyAlreadyExist"));
            }
        }

        [TestMethod]
        public void Security_Permission_UpdateRole_ShouldGetException_WithEmptyID()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid();
                string key = "Key of Role" + Guid.NewGuid();
                string desc = "Desc of Role";
                this.UpdateRoleItem(Guid.Empty, name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.roles.validation.idIsInvalid"));
            }
        }

        [TestMethod]
        public void Security_Permission_UpdateRole_ShouldGetException_WithNotExistedID()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid();
                string key = "Key of Role" + Guid.NewGuid();
                string desc = "Desc of Role";
                this.UpdateRoleItem(Guid.NewGuid(), name, key, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.roles.validation.idIsInvalid"));
            }
        }
        private CreateRoleResponse CreateRoleItem(string name, string key, string desc)
        {
            CreateRoleRequest request = new CreateRoleRequest(name, key, desc);
            IRoleService service = IoC.Container.Resolve<IRoleService>();
            return service.Create(request);
        }

        private void UpdateRoleItem(Guid id, string name, string key, string desc)
        {
            UpdateRoleRequest request = new UpdateRoleRequest(id, name, key, desc);
            IRoleService service = IoC.Container.Resolve<IRoleService>();
            service.Update(request);
        }
    }
}
