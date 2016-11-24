namespace App.Service.Inventory
{
    using System;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IList<CategoryListItem> GetCategories();
        void CreateIfNotExist(List<CreateCategoryRequest> categories);
        GetCategoryResponse GetById(string itemId);
        Category Create(CreateCategoryRequest request);
        void Update(UpdateCategoryRequest request);
        void DeleteCategory(Guid id);
    }
}