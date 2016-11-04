using App.Common.Data;
using App.Common.Mapping;
using App.Service.Common.File;
using System;
using System.Collections.Generic;

namespace App.Service.ProductManagement.Product
{
    public class UpdateProductRequest: BaseContent, IMappedFrom<App.Entity.ProductManagement.Product>
    {
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Guid CategoryId { get; set; }
        public IList<FileUploadResponse> Photos { get; set; }
    }
}
