namespace App.Service.Impl.Blog
{
    using System;
    using System.Collections.Generic;
    using App.Service.Blog;
    using Repository.Setting;
    using App.Common.DI;
    using Entity.Blog;
    using App.Common;

    internal class BlogCategoryService : IBlogCategoryService
    {
        public IList<CategoryListItem> GetCategories()
        {
            IContentTypeInstanceRepository repo = IoC.Container.Resolve<IContentTypeInstanceRepository>();
            IList<ContentTypeInstance> items = repo.GetByContentType(TypeOfContentType.BlogCategory);
            IList<CategoryListItem> result = new List<CategoryListItem>();
            foreach (ContentTypeInstance item in items) {
                CategoryListItem resultItem = ContentTypeHelper.Convert<CategoryListItem>(item);
                result.Add(resultItem);
            }
            return result;
        }
    }
}
