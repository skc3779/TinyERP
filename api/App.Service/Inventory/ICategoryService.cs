namespace App.Service.Inventory
{
    using Entity.Inventory;
    using System;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IList<CategoryListItem> GetCategories();
        void CreateIfNotExist(List<CreateCategoryRequest> categories);
        GetCategoryResponse GetCategory(Guid id);
        Category Create(CreateCategoryRequest request);
        void Update(UpdateCategoryRequest request);
        void Delete(Guid id);
    }
}