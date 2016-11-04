
using App.Common;
using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;

namespace App.Service.ProductManagement.Category
{
    public class CreateCategoryResponse: BaseContent, IMappedFrom<ProductCategory>
    {
        public ItemStatus Status { get; set; }
        public CreateCategoryResponse() : base()
        {
            this.Status = ItemStatus.None;
        }
    }
}
