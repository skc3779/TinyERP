namespace App.Service.Security.Role
{
    using App.Common.Data;
    using App.Common.Mapping;

    public class RoleKeyNamePair : BaseEntity, IMappedFrom<App.Entity.Security.Role>
    {
        public string Name { get; set; }
    }
}
