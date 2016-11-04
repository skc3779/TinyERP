using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using System;

namespace App.Service.ProductManagement.Category
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
        public Guid ParentId { get; set; }
        public CreateCategoryRequest() : base()
        {
            this.Status = ItemStatus.None;
        }
    }
}
