import { OrderStatus } from "../_share/models/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "orders_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any, ctr: any) {
        this.options = {
            columns: [
                // { field: "number", title: resourceHelper.resolve("store.orders.grid.orderNumber") },
                { field: "contact", title: resourceHelper.resolve("store.orders.grid.contactName"), render: function (data: any) { return data ? data.name : String.empty; } },
                { field: "contact", title: resourceHelper.resolve("store.orders.grid.contactEmail"), render: function (data: any) { return data ? data.email : String.empty; } },
                { field: "contact", title: resourceHelper.resolve("store.orders.grid.contactPhone"), render: function (data: any) { return data ? data.phone : String.empty; } },
                { field: "price", title: resourceHelper.resolve("store.orders.grid.price") },
                { field: "numberOfItems", title: resourceHelper.resolve("store.orders.grid.numberOfItems") },
                {
                    field: "status", title: resourceHelper.resolve("store.orders.grid.status"), render: function (data: any) {
                        let key = OrderStatus[data];
                        key = String.firstCharToLower(key);
                        return resourceHelper.resolve(String.format("store.orders.status.{0}", key));
                    }
                },
                { field: "transactionDate", title: resourceHelper.resolve("store.orders.grid.transactionDate") }
            ],
            data: [],
            actions: [
                { text: resourceHelper.resolve("common.form.view"), handler: (item: any) => ctr.onViewItemClicked(item) }
            ],
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