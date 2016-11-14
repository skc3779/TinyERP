using System.Collections.Generic;
using App.Entity.ProductManagement;

namespace App.Service.Inventory
{
    public interface IProductCategoryService
    {
        IList<CategoryListItem> GetProductCategories();
        void CreateIfNotExist(IList<ProductCategory> categories);
    }
}
