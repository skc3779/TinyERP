namespace App.Service.Inventory
{
    using System;
    using App.Common;
    using App.Common.Validation.Attribute;

    public class UpdateCategoryRequest
    {
        public Guid Id { get; set; }
        [ValueInRange("inventory.addOrUpdateCategory.validation.fieldTooLong",0, FormValidationRules.MaxNameLength)]
        [Required("inventory.addOrUpdateCategory.validation.nameRequired")]
        public string Name { get; set; }
        [ValueInRange("inventory.addOrUpdateCategory.validation.fieldTooLong", 0 , FormValidationRules.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}