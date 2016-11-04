using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Common;
using App.Entity.ProductManagement;
using App.Service.Common;
using System;
using System.Collections.Generic;

namespace App.Service.ProductManagement.Product
{
    public class GetProductResponse: BaseContent, IMappedFrom<App.Entity.ProductManagement.Product>
    {
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public IList<FileUploadPreview> Photos { get; set; }
        public GetProductResponse(): base()
        {
            this.Photos = new List<FileUploadPreview>();
        }
    }
}
