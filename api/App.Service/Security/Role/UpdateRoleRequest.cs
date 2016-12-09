namespace App.Service.Security.Role
{
    using App.Common.Data;
    using System.Collections.Generic;
    using System;
    using App.Common.Mapping;
    using App.Entity.Security;
    using App.Common.Validation.Attribute;

    public class UpdateRoleRequest
    {
        [Required("common.validation.invalidRequest")]
        public Guid Id { get; set; }
        [Required("security.addOrUpdateRole.validation.nameIsRequired")]
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
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
