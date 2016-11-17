namespace App.Repository.Registration
{
    using App.Common.Data;
    using App.Entity.Registration;

    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);
        User GetByToken(string token);
    }
}
