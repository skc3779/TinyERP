using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Inventory;

namespace App.Repository.Inventory
{
    public interface ICategoryRepository : IBaseContentRepository<Category>
    {
        System.Collections.Generic.IList<TResult> GetCategories<TResult>() where TResult : IMappedFrom<Category>;
    }
}
