namespace App.Service.Inventory
{
    using App.Common.Validation.Attribute;

    public class CreateCategoryRequest
    {
        [Required("inventory.addOrUpdateCategory.validation.nameRequired")]
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryRequest(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
