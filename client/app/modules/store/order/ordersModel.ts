import { OrderStatus } from "../_share/models/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "orders_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "number", title: resourceHelper.resolve("store.accounts.grid.orderNumber") },
                { field: "contact", title: resourceHelper.resolve("store.accounts.grid.contactName"), render: function (data: any) { return data ? data.name : String.empty; } },
                { field: "contact", title: resourceHelper.resolve("store.accounts.grid.contactEmail"), render: function (data: any) { return data ? data.email : String.empty; } },
                { field: "contact", title: resourceHelper.resolve("store.accounts.grid.contactPhone"), render: function (data: any) { return data ? data.phone : String.empty; } },
                { field: "price", title: resourceHelper.resolve("store.accounts.grid.price") },
                { field: "numberOfItems", title: resourceHelper.resolve("store.accounts.grid.numberOfItems") },
                {
                    field: "status", title: resourceHelper.resolve("store.accounts.grid.status"), render: function (data: any) {
                        let key = OrderStatus[data];
                        key = String.firstCharToLower(key);
                        return resourceHelper.resolve(String.format("store.orders.status.{0}", key));
                    }
                },
                { field: "transactionDate", title: resourceHelper.resolve("store.accounts.grid.transactionDate") }
            ],
            data: []
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