namespace App.Repository.Common
{
    using System;
    using System.Collections.Generic;
    using App.Common.Data;
    using App.Entity.Common;

    public interface IFileRepository : IBaseRepository<FileUpload>
    {
        IList<TEntity> GetByIds<TEntity>(IList<Guid> ids);
    }
}
