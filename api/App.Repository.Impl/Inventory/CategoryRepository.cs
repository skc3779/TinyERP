using System.Collections.Generic;
using App.Common.Data;
using App.Common.Mapping;
using App.Repository.Inventory;
using App.Common.Data.MSSQL;
using App.Context;
using App.Entity.Inventory;

namespace App.Repository.Impl.Inventory
{
    public class CategoryRepository : BaseContentRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
        public CategoryRepository() : base(new AppDbContext(App.Common.IOMode.Read)) { }
    }
}
