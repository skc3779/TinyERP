using App.Common.Data;

namespace App.Entity.Support
{
    public class Request:BaseEntity
    {
        public Request(string subject, string description, string email)
        {
            this.Subject = subject;
            this.Description = description;
            this.Email = email;
        }

        public string Subject { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
