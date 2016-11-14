import { ValidationException } from "../../../common/models/exceptions/ValidationException";
import { MaxLenghtForFields } from "../../../common/enum";
export class AddOrUpdateCategoryModel {
    public id: string;
    public name: string;
    public description: string;
    public validate(): boolean {
        let validation: ValidationException = new ValidationException();
        if (String.isNullOrWhiteSpace(this.name)) {
            validation.add("inventory.addOrUpdateCategory.validation.nameIsRequired");
        }
        if (this.name.length > MaxLenghtForFields.Name) {
            validation.add(String.format("inventory.addOrUpdateCategory.validation.fieldTooLong", MaxLenghtForFields.Name));
        }
        if (String.isNullOrWhiteSpace(this.name) && this.description.length > MaxLenghtForFields.Description) {
            validation.add(String.format("inventory.addOrUpdateCategory.validation.fieldTooLong", MaxLenghtForFields.Description));
        }
        validation.throwIfHasError();
        return !validation.hasError();
    }
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.description = item.description;
    }
}