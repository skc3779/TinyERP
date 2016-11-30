namespace App.Service.Inventory
{
    using System;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IList<CategoryListItem> GetCategories();
        void CreateIfNotExist(List<CreateCategoryRequest> categories);
        GetCategoryResponse GetCategory(Guid id);
        CreateCategoryReponse Create(CreateCategoryRequest request);
        void Update(UpdateCategoryRequest request);
        void Delete(Guid id);
    }
}