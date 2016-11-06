using App.Common;
using System;

namespace App.Service.Store
{
    public class UpdateAccountRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ItemStatus Status { get; set; }
        public string Description { get; set; }
        public Guid Photo { get; set; }
    }
}
