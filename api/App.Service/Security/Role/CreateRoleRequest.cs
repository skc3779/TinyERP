namespace App.Service.Security.Role
{
    using App.Common.Data;
    using System.Collections.Generic;
    using System;
    using App.Common.Mapping;
    using App.Entity.Security;
    using App.Common.Validation.Attribute;

    public class CreateRoleRequest
    {
        [Required("security.addOrUpdateRole.validation.nameIsRequired")]
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
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
    }
}
