using App.Common;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Entity.ProductManagement;
using App.Repository.ProductManagement;
using System.Linq;

namespace App.Repository.Impl.ProductManagement
{
    public class CategoryRepository : BaseContentRepository<ProductCategory>, ICategoryRepository
    {
        public CategoryRepository() : base(new AppDbContext(IOMode.Read))
        {
        }
        public CategoryRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {
        }
    }
}
