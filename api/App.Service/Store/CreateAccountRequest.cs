using App.Common;
using System;

namespace App.Service.Store
{
    public class CreateAccountRequest
    {
        //for EF only
        public CreateAccountRequest()
        {
        }
        public CreateAccountRequest(string name, string email, string userName, string description)
        {
            this.Name = name;
            this.Email = email;
            this.UserName = userName;
            this.Description = description;
            this.Photo = Guid.Empty;
            this.Status = StoreAccountStatus.InActive;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public StoreAccountStatus Status { get; set; }
        public string Description { get; set; }
        public Guid Photo { get; set; }
    }
}
