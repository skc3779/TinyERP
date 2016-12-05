namespace App.Service.Security.Role
{
    using App.Common.Data;
    using System.Collections.Generic;
    using System;
    using App.Common.Mapping;
    using App.Entity.Security;

    public class UpdateRoleRequest : BaseContent, IMappedFrom<Role>
    {
        public IList<Guid> Permissions { get; set; }
        public UpdateRoleRequest() : base()
        {
            this.Permissions = new List<Guid>();
        }

        public UpdateRoleRequest(Guid id, string name, string key, string desc) : base()
        {
            this.Id = id;
            this.Name = name;
            this.Key = key;
            this.Description = desc;
            this.Permissions = new List<Guid>();
        }
    }
}
