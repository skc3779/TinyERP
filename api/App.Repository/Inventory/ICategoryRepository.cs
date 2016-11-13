using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;

namespace App.Repository.Inventory
{
    public interface ICategoryRepository : IBaseContentRepository<ProductCategory>
    {
        System.Collections.Generic.IList<TResult> GetCategories<TResult>() where TResult : IMappedFrom<ProductCategory>;
    }
}
