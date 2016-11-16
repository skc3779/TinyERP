using App.Common.Data;
using App.Common.Mapping;

namespace App.Service.Inventory
{
    public class CategoryListItem : BaseContent, IMappedFrom<App.Entity.Inventory.Category>
    {
        public CategoryListItem() { }
        public CategoryListItem(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
