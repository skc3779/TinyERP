using App.Common.Data;
using App.Common.Mapping;
using App.Entity.ProductManagement;
using System;

namespace App.Service.ProductManagement.Product
{
    public class ProductListItem: BaseContent, IMappedFrom<App.Entity.ProductManagement.Product>
    {
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ProductListItem(): base()
        {
        }
    }
}
