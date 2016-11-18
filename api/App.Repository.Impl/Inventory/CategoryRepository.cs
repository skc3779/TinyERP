using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Entity.Inventory;
using App.Repository.Inventory;

namespace App.Repository.Impl.Inventory
{
    public class CategoryRepository : BaseContentRepository<Category>, ICategoryRepository
    {
        public CategoryRepository() : base(new AppDbContext(App.Common.IOMode.Read)) { }
        public CategoryRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
    }
}
