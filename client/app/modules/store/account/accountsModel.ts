import {ItemStatus} from "../../../common/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "accounts_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "name", title: resourceHelper.resolve("store.accounts.grid.name") },
                { field: "email", title: resourceHelper.resolve("store.accounts.grid.email") },
                { field: "userName", title: resourceHelper.resolve("store.accounts.grid.userName") },
                {
                    field: "status", title: resourceHelper.resolve("store.accounts.grid.status"), render: function (data: any) {
                        let key = ItemStatus[data];
                        key = String.firstCharToLower(key);
                        return resourceHelper.resolve(String.format("common.itemStatus.{0}", key));
                    }
                },
                { field: "description", title: resourceHelper.resolve("store.accounts.grid.description") }
            ],
            data: [],
            enableEdit: true,
            enableDelete: true
        };
    }
    public addPageAction(action: any) {
        this.actions.push(action);
    }
    public import(items: Array<any>) {
        let eventManager = window.ioc.resolve("IEventManager");
        eventManager.publish(this.eventKey, items);
    }
}