using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;
using System;

namespace App.Service.ProductManagement.Category
{
    public class GetCategoryResponse : BaseContent, IMappedFrom<ProductCategory>
    {
        public Guid ParentId { get; set; }
        public ItemStatus Status { get; set; }
        public GetCategoryResponse() : base()
        {
            this.Status = ItemStatus.None;
        }
    }
}
