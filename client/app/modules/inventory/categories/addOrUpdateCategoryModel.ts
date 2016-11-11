import { ValidationException } from "../../../common/models/exceptions/ValidationException";
export class AddOrUpdateCategoryModel {
    public id: string;
    public name: string;
    public description: string;
    public validate(): boolean {
        let validation: ValidationException = new ValidationException();
        if (String.isNullOrWhiteSpace(this.name)) {
            validation.add("inventory.addOrUpdateCategory.validation.nameIsRequired");
        }
        if (this.name.length > 50) {
            validation.add(String.format("inventory.addOrUpdateCategory.validation.fieldTooLong", 50));
        }
        if (this.description.length > 512) {
            validation.add(String.format("inventory.addOrUpdateCategory.validation.fieldTooLong", 512));
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