using System;
using App.Common;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Entity.ProductManagement;
using App.Repository.ProductManagement;
using System.Linq;

namespace App.Repository.Impl.ProductManagement
{
    public class ProductRepository : BaseContentRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new AppDbContext(IOMode.Read)) { }
        public ProductRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }

        public bool Exists(Guid productId)
        {
            return this.DbSet.AsQueryable().Any(item => item.Id == productId);
        }
    }
}
