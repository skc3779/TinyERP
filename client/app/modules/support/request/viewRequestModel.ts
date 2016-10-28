import {KeyNamePair} from "../../../common/models/keyNamePair";
import {ItemStatus} from "../../../common/enum";
export class Model {
    public subject: string = String.empty;
    public description: string = String.empty;
    public email: string = String.empty;
    public createdDate: string=String.empty;
    public status: ItemStatus;
    public import(item: any){
        this.subject = item.subject;
        this.email = item.email;
        this.description = item.description;
        this.createdDate = item.createdDate;
        this.status = item.status;
    }
}