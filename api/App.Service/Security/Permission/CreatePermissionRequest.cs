namespace App.Service.Security.Permission
{
    using App.Common.Data;
    using App.Common.Mapping;
    using App.Common.Validation.Attribute;

    public class CreatePermissionRequest : BaseContent, IMappedFrom<App.Entity.Security.Permission>
    {
        [Required("security.addPermission.validation.nameIsRequire")]
        public new string Name { get; set; }

        [Required("security.addPermission.validation.keyIsRequire")]
        public new string Key { get; set; }
    }
}