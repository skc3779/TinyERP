namespace App.Entity.Common
{
    using App.Common.Data;

    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string IsoCode { get; set; }
        public string Description { get; set; }
        public Language(string name, string code, string isoCode) : base()
        {
            this.Name = name;
            this.Code = code;
            this.IsoCode = isoCode;
        }
    }
}
