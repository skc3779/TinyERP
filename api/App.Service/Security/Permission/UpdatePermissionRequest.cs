namespace App.Service.Security.Permission
{
    using App.Common.Validation.Attribute;
    using System;

    public class UpdatePermissionRequest
    {
        public Guid Id { get; set; }
        [Required("security.addPermission.validation.nameIsRequire")]
        public string Name { get; set; }
        [Required("security.addPermission.validation.keyIsRequire")]
        public string Key { get; set; }
        public string Description { get; set; }
    }
}
