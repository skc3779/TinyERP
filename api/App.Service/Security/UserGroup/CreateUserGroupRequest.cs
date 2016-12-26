namespace App.Service.Security.UserGroup
{
    using App.Common.Data;
    using App.Common.Mapping;
    using App.Entity.Security;
    using System;
    using System.Collections.Generic;

    public class CreateUserGroupRequest : BaseContent, IMappedFrom<App.Entity.Security.UserGroup>
    {
        public IList<Guid> PermissionIds { get; set; }
        public CreateUserGroupRequest() : base()
        {
            this.PermissionIds = new List<Guid>();
        }

        public CreateUserGroupRequest(string name, string desc) : base()
        {
            this.Name = name;
            this.Description = desc;
            this.PermissionIds = new List<Guid>();
        }
    }
}
