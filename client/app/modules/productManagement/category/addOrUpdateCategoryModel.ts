import {KeyNamePair} from "../../../common/models/keyNamePair";
export class Model {
    public id: string = String.empty;
    public name: string = String.empty;
    public description: string = String.empty;
    public status: boolean = true;
    public parentId: string = String.empty;
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.status = item.status;
        this.description = item.description;
        this.parentId = item.parentId;
    }
}