namespace App.Service.Inventory
{
    using System.Collections.Generic;
    using App.Entity.Inventory;

    public interface ICategoryService
    {
        IList<CategoryListItem> GetCategories();
        void CreateIfNotExist(List<CreateCategoryRequest> categories);
        GetCategoryResponse GetById(string itemId);
        Category Create(CreateCategoryRequest request);
        void Update(string itemId, UpdateCategoryRequest request);
    }
}