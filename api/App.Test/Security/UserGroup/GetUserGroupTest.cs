namespace App.Test.Security.UserGroup
{
    using System;
    using System.Collections.Generic;
    using Service.Security;
    using Common.UnitTest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Common.DI;

    [TestClass]
    public class GetUserGroupTest : BaseUnitTest
    {
        [TestMethod]
        public void Sercurity_UserGroup_GetUserGroup_ShouldBeSusscess_WithExistedUserGroup()
        {
            string name = "name of role" + Guid.NewGuid();
            string description = "description of role";
            CreateUserGroupRequest userGroupRequest = new CreateUserGroupRequest()
            {
                Name = name,
                Description = description
            };

            IUserGroupService userGroupService = IoC.Container.Resolve<IUserGroupService>();
            userGroupService.Create(userGroupRequest);
            Assert.IsTrue(userGroupService.GetUserGroups().Count > 0);
        }
    }
}
