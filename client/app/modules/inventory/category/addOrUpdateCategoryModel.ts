import { ValidationException } from "../../../common/models/exceptions/ValidationException";
import { FormValidationRules } from "../../../common/enum";
export class Model {
    public id: string;
    public name: string;
    public description: string;
    public validate(): boolean {
        let validation: ValidationException = new ValidationException();
        if (String.isNullOrWhiteSpace(this.name)) {
            validation.add("inventory.addOrUpdateCategory.validation.nameIsRequired");
        }
        if (this.name.length > FormValidationRules.maxNameLength) {
            validation.add(String.format("inventory.addOrUpdateCategory.validation.fieldTooLong", FormValidationRules.maxNameLength));
        }
        if (String.isNullOrWhiteSpace(this.description) && this.description.length > FormValidationRules.maxDescriptionLength) {
            validation.add(String.format("inventory.addOrUpdateCategory.validation.fieldTooLong", FormValidationRules.maxDescriptionLength));
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