using App.Common.Data;
using System;

namespace App.Entity.Blog
{
    public class ContentTypeInstance : BaseContent
    {
        public string ContentType { get; set; }
        public Guid ContentTypeId { get; set; }
        public string Json { get; set; }
    }
}
