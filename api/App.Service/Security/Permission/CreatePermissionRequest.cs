namespace App.Service.Security.Permission
{
    using App.Common;
    using App.Common.Validation.Attribute;
    using Entity.Security;

    public class CreatePermissionRequest
    {
        //[Unique("security.addPermission.validation.nameAlreadyExist", typeof(App.Entity.Security.Permission), new ValidatorOption(DataOperationType.Create, PermissionField.Name.ToString()))]
        [Required("security.addPermission.validation.nameIsRequire")]
    public string Name { get; set; }

    [Required("security.addPermission.validation.keyIsRequire")]
    public string Key { get; set; }

    public string Description { get; set; }

    public CreatePermissionRequest(string name, string key, string desc)
    {
        this.Name = name;
        this.Key = key;
        this.Description = desc;
    }
}
}