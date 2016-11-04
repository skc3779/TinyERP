import {ItemStatus} from "../../../common/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "products_ondatasource_changed";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "name", title: resourceHelper.resolve("productManagement.products.grid.name"), index: 0 },
                {
                    field: "status", title: resourceHelper.resolve("productManagement.products.grid.status"), index: 1, render: function (data: any) {
                        return data === ItemStatus.Active ? resourceHelper.resolve("common.form.status.active") : resourceHelper.resolve("common.form.status.inactive");
                    }
                },
                { field: "description", title: resourceHelper.resolve("productManagement.products.grid.description"), index: 2 },
                { field: "price", title: resourceHelper.resolve("productManagement.products.grid.price"), index: 3 },
                { field: "fromDate", title: resourceHelper.resolve("productManagement.products.grid.fromDate"), index: 4 },
                { field: "toDate", title: resourceHelper.resolve("productManagement.products.grid.toDate"), index: 5 },
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