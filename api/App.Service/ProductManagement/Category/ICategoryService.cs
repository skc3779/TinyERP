using System;

namespace App.Service.ProductManagement.Category
{
    public interface ICategoryService
    {
        System.Collections.Generic.IList<CategoryListItem> GetCategories();
        GetCategoryResponse Get(Guid id);
        CreateCategoryResponse Create(CreateCategoryRequest request);
        void Update(UpdateCategoryRequest request);
        DeleteCategoryResponse Delete(Guid id);
        App.Entity.ProductManagement.ProductCategory GetByName(string categoryName);
    }
}
