namespace App.Test.Security.Role
{
    using App.Common;
    using App.Common.DI;
    using App.Common.Validation;
    using App.Service.Security.Role;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class CreateRoleTest
    {
        [TestMethod]
        public void Security_Role_CreateRole_ShouldBeSuccess_WithValidRequest()
        {
            string name = "Name of Role" + Guid.NewGuid().ToString("N");
            string key = "Key of Role" + Guid.NewGuid().ToString("N");
            string description = "Desc of Role";
            CreateRoleResponse role = this.CreateRoleItem(name, key, description);
            Assert.IsNotNull(role);
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldGetException_WithEmptyName()
        {
            try
            {
                string name = string.Empty;
                string description = "Desc of Role";
                string key = "Key of Role" + Guid.NewGuid().ToString("N");
                this.CreateRoleItem(name, key, description);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.nameRequired"));
            }
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldGetException_WithDuplicateName()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid().ToString("N");
                string description = "Desc of Role";
                string key1 = "Key of Role" + Guid.NewGuid().ToString("N");
                string key2 = "Key of Role" + Guid.NewGuid().ToString("N");
                this.CreateRoleItem(name, key1, description);
                this.CreateRoleItem(name, key2, description);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.nameAlreadyExist"));
            }
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldGetException_WithEmptyKey()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid().ToString("N");
                string key = string.Empty;
                string description = "Desc of Role";
                this.CreateRoleItem(name, key, description);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.keyIsRequired"));
            }
        }


        [TestMethod]
        public void Security_Role_CreateRole_ShouldGetException_WithDuplicateKey()
        {
            try
            {
                string name1 = "Name of Role" + Guid.NewGuid().ToString("N");
                string name2 = "Name of Role" + Guid.NewGuid().ToString("N");
                string description = "Desc of Role";
                string key = "Key of Role" + Guid.NewGuid().ToString("N");
                this.CreateRoleItem(name1, key, description);
                this.CreateRoleItem(name2, key, description);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.keyAlreadyExist"));
            }
        }


        [TestMethod]
        public void Security_Role_CreateRole_ShouldGetException_WithNameTooLong()
        {
            try
            {
                string name = "Name of Role" + new string('g', FormValidationRules.MaxNameLength);
                string key = "Key of Role" + Guid.NewGuid().ToString("N");
                string description = "Desc of Role";
                this.CreateRoleItem(name, key, description);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.fieldTooLong"));
            }
        }

        [TestMethod]
        public void Security_Role_CreateRole_ShouldGetException_WithDescriptionTooLong()
        {
            try
            {
                string name = "Name of Role" + Guid.NewGuid().ToString("N");
                string key = "Key of Role" + Guid.NewGuid().ToString("N");
                string description = "Desc of Role " + new string('g', FormValidationRules.MaxNameLength);
                this.CreateRoleItem(name, key, description);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("security.addOrUpdateRole.validation.fieldTooLong"));
            }
        }

        private CreateRoleResponse CreateRoleItem(string name, string key, string desc)
        {
            CreateRoleRequest request = new CreateRoleRequest(name, key, desc);
            IRoleService service = IoC.Container.Resolve<IRoleService>();
            return service.Create(request);
        }
    }
}