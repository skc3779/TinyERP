namespace App.Service.Inventory
{
    public interface ICategoryService
    {
        GetCategoryResponse GetById(string itemId);
        void Create(CreateCategoryRequest request);
        void Update(string itemId, UpdateCategoryRequest request);
    }
}
