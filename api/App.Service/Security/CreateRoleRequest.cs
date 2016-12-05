namespace App.Service.Security
{
    using App.Common.Data;
    using System.Collections.Generic;
    using System;
    using App.Common.Mapping;
    using App.Entity.Security;

    public class CreateRoleRequest : BaseContent, IMappedFrom<Role>
    {
        public IList<Guid> Permissions { get; set; }
        public CreateRoleRequest() : base()
        {
            this.Permissions = new List<Guid>();
        }
        public CreateRoleRequest(string name, string desc) : base()
        {
            this.Name = name;
            this.Description = desc;
            this.Permissions = new List<Guid>();
        }
        public CreateRoleRequest(string name, string key, string desc) : base()
        {
            this.Name = name;
            this.Description = desc;
            this.Key = key;
            this.Permissions = new List<Guid>();
        }
    }
}
