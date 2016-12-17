namespace App.Service.Security
{
    using App.Common.Validation.Attribute;
    using System;
    using System.Collections.Generic;

    public class CreateUserGroupRequest
    {
        [Required("security.addOrUpdateUserGroup.validation.nameIsRequire")]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Guid> PermissionIds { get; set; }
        public CreateUserGroupRequest() : base()
        {
            this.PermissionIds = new List<Guid>();
        }
    }
}
