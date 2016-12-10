namespace App.Repository.Setting
{
    using System.Collections.Generic;
    using App.Common.Data;
    using App.Entity.Blog;

    public interface IContentTypeInstanceRepository : IBaseRepository<ContentTypeInstance>
    {
        IList<ContentTypeInstance> GetByContentType(string contentType);
    }
}
