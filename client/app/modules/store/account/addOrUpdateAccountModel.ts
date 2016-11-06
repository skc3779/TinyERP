import {KeyNamePair} from "../../../common/models/keyNamePair";
import {AccountStatus} from "../_share/models/enum";
export class Model {
    public id: string = String.empty;
    public name: string = String.empty;
    public email: string = String.empty;
    public userName: string = String.empty;
    public status: AccountStatus = AccountStatus.InActive;
    public description: string = String.empty;
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.email = item.email;
        this.userName = item.userName;
        this.status = item.status;
        this.description = item.description;
    }
}