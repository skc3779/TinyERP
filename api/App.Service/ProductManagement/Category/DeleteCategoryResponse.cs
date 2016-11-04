using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;

namespace App.Service.ProductManagement.Category
{
    public class DeleteCategoryResponse: BaseContent, IMappedFrom<ProductCategory>
    {
    }
}
