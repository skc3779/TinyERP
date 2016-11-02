import {KeyNamePair} from "../../../common/models/keyNamePair";
import {ItemStatus} from "../../../common/enum";
import {PageAction} from "../../../common/models/ui";

export class Model {
    public id: string = String.empty;
    public subject: string = String.empty;
    public description: string = String.empty;
    public email: string = String.empty;
    public createdDate: string = String.empty;
    public status: ItemStatus;
    public actions: Array<any> = [];
    public import(item: any) {
        this.id = item.id;
        this.subject = item.subject;
        this.email = item.email;
        this.description = item.description;
        this.createdDate = item.createdDate;
        this.status = item.status;
    }
    constructor(ctr: any) {
        let self = this;
        this.addPageAction(new PageAction("btnResolved", "support.viewRequest.actions.markAsResolved", () => ctr.onMarkAsResolvedClicked(self)));
        this.addPageAction(new PageAction("btnCancel", "support.viewRequest.actions.cancelRequest", () => ctr.onCancelRequestClicked(self)));
    }
    public addPageAction(action: any) {
        this.actions.push(action);
    }
}