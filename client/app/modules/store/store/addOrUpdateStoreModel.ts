import {KeyNamePair} from "../../../common/models/keyNamePair";
export class Model {
    public id: string = String.empty;
    public name: string = String.empty;
    public owner: any = { id: "", name: "" };
    public status: boolean = true;
    public description: string = String.empty;
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.status = item.status;
        this.description = item.description;
        if (item.owner) {
            this.owner.id = item.owner.id;
            this.owner.name = item.owner.name;
        }
    }
}