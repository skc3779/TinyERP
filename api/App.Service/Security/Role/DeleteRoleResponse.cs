namespace App.Service.Security.Role
{
    using App.Common.Data;
    using App.Common.Mapping;
    using App.Entity.Security;

    public class DeleteRoleResponse : BaseContent, IMappedFrom<Role>
    {
    }
}
