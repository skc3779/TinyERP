using System;

namespace App.Service.ProductManagement.Product
{
    public interface IProductService
    {
        System.Collections.Generic.IList<ProductListItem> GetProducts();
        void Delete(Guid id);
        GetProductResponse Get(Guid id);
        CreateProductResponse Create(CreateProductRequest request);
        void Update(UpdateProductRequest request);
    }
}
