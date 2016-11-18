namespace App.Service.Inventory
{
    public class CreateCategoryRequest
    {
        public CreateCategoryRequest(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}