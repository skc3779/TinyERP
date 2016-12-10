namespace App.Service.Blog
{
    using App.Common.Data;
    using App.Common.Mapping;
    using App.Entity.Blog;

    public class CategoryListItem : BaseContent, IMappedFrom<ContentTypeInstance>
    {
    }
}
