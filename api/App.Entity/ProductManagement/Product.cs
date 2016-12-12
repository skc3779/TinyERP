namespace App.Entity.ProductManagement
{
    using App.Common.Data;
    using System;

    public class Product : BaseContent
    {
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        //TODO: I think a product can be in more than one store at the same time and at each store have diferent quantities and status.
        public Store.Store Store { get; set; }
        public string Attachments { get; set; }
        public Product() : base()
        {
            this.FromDate = null;
            this.ToDate = null;
        }
    }
}
