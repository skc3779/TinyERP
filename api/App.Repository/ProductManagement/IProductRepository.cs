using System;
using App.Common.Data;

namespace App.Repository.ProductManagement
{
    public interface IProductRepository : IBaseContentRepository<App.Entity.ProductManagement.Product>
    {
        bool Exists(Guid productId);
    }
}
