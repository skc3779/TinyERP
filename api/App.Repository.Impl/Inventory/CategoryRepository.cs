using System;
using System.Collections.Generic;
using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;
using App.Repository.Inventory;
using App.Common.Data.MSSQL;
using App.Context;

namespace App.Repository.Impl.Inventory
{
    public class CategoryRepository : BaseContentRepository<ProductCategory>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
        public CategoryRepository() : base(new AppDbContext(App.Common.IOMode.Read)) { }
        public IList<TResult> GetCategories<TResult>() where TResult : IMappedFrom<ProductCategory>
        {
            return this.GetItems<TResult>();
        }
    }
}
