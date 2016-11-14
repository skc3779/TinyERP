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
    public class ProductCategoryRepository : BaseContentRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
        public ProductCategoryRepository() : base(new AppDbContext(App.Common.IOMode.Read)) { }
        public IList<TResult> GetProductCategories<TResult>() where TResult : IMappedFrom<ProductCategory>
        {
            return this.GetItems<TResult>();
        }
    }
}
