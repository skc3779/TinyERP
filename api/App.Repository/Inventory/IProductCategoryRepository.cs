using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;

namespace App.Repository.Inventory
{
    public interface IProductCategoryRepository : IBaseContentRepository<ProductCategory>
    {
        System.Collections.Generic.IList<TResult> GetProductCategories<TResult>() where TResult : IMappedFrom<ProductCategory>;
    }
}
