namespace App.Service.Security.Role
{
    using App.Common.Data;
    using System.Collections.Generic;
    using System;
    using App.Common.Mapping;
    using App.Entity.Security;

    public class CreateRoleRequest : BaseContent, IMappedFrom<Role>
    {
        public IList<Guid> Permissions { get; set; }
        public CreateRoleRequest()
            : base()
        {
            this.Permissions = new List<Guid>();
        }

        public CreateRoleRequest(string name, string key, string desc)
            : base()
        {
            this.Name = name;
            this.Key = key;
            this.Description = desc;
            this.Permissions = new List<Guid>();
        }
    }
}
