namespace App.Service.Blog
{
    public interface IBlogCategoryService
    {
        System.Collections.Generic.IList<CategoryListItem> GetCategories();
    }
}
