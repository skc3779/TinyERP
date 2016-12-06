namespace App.Service.Inventory
{
    using System;
    using App.Common;
    using App.Common.Validation.Attribute;

    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        [Required("inventory.addOrUpdateCategory.validation.nameRequired")]
        [ValueInRange("inventory.addOrUpdateCategory.validation.nameTooLong", 0, FormValidationRules.MaxNameLength)]
        public string Name { get; set; }
        [ValueInRange("inventory.addOrUpdateCategory.validation.descriptionTooLong", 0, FormValidationRules.MaxNameLength)]
        public string Description { get; set; }
    }
}