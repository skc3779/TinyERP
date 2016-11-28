namespace App.Service.Inventory
{
    using System;

    public class CreateCategoryReponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryReponse(Guid id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
