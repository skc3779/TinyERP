namespace App.Service.Registration.User
{
    using System.Collections.Generic;

    public interface IUserService
    {
        UserSignInResponse SignIn(UserSignInRequest request);
        void CreateIfNotExist(IList<Entity.Registration.User> users);
        void SignOut(string token);
        bool IsValidToken(string authenticationToken);
    }
}
