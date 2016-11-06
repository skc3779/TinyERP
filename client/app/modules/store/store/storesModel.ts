import {ItemStatus} from "../../../common/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "stores_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "name", title: resourceHelper.resolve("store.stores.grid.name") },
                {
                    field: "owner", title: resourceHelper.resolve("store.stores.grid.owner"), index: 1, render: function (data: any) { return data ? data.name : String.empty; }
                },
                {
                    field: "status", title: resourceHelper.resolve("store.stores.grid.status"), index: 1, render: function (data: any) {
                        let key = ItemStatus[data];
                        key = String.firstCharToLower(key);
                        return resourceHelper.resolve(String.format("common.itemStatus.{0}", key));
                    }
                },
                { field: "description", title: resourceHelper.resolve("store.stores.grid.description") }
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