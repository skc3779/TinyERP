using System.Collections.Generic;
using App.Entity.ProductManagement;

namespace App.Service.Inventory
{
    public interface ICategoryService
    {
        IList<CategoryListItem> GetCategories();
        void CreateIfNotExist(IList<ProductCategory> categories);
    }
}
