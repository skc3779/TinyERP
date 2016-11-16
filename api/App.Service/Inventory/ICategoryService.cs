using System.Collections.Generic;
using App.Entity.Inventory;

namespace App.Service.Inventory
{
    public interface ICategoryService
    {
        IList<CategoryListItem> GetCategories();
        void CreateIfNotExist(IList<Category> categories);
    }
}
