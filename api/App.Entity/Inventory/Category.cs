using App.Common.Data;

namespace App.Entity.Inventory
{
    public class Category : BaseContent
    {
        public Category() { }
        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
