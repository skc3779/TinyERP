using App.Common.Data;
using System;
using System.Collections.Generic;

namespace App.Service.ProductManagement.Product
{
    public class CreateProductRequest : BaseContent
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid StoreId { get; set; }
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public IList<Guid> Photos { get; set; }
        public CreateProductRequest(): base()
        {
            this.Photos = new List<Guid>();
        }
    }
}
