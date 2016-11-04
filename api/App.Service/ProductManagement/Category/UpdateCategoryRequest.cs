using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using System;

namespace App.Service.ProductManagement.Category
{
    public class UpdateCategoryRequest: BaseContent, IMappedFrom<ProductCagegory>
    {
        public Guid ParentId { get; set; }
        public ItemStatus Status { get; set; }
        public UpdateCategoryRequest(): base()
        {
            this.Status = ItemStatus.None;
        }
    }
}
