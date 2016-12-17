namespace App.Service.Security.UserGroup
{
    using App.Common.Validation.Attribute;
    using System;
    using System.Collections.Generic;

    public class UpdateUserGroupRequest
    {
        [Required("common.validation.inValidRequest")]
        public Guid Id { get; set; }
        [Required("security.addOrUpdateUserGroup.validation.nameIsRequire")]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Guid> PermissionIds { get; set; }
        public UpdateUserGroupRequest() : base()
        {
            this.PermissionIds = new List<Guid>();
        }
    }
}
