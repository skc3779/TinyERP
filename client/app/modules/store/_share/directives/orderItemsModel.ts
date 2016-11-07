export class Model {
    public options: any = {};
    constructor(resourceHelper: any, ctr: any) {
        this.options = {
            columns: [
                { field: "product", title: resourceHelper.resolve("store.viewOrder.orderItems.productName"), render: function (data: any) { return data ? data.name : String.empty; } },
                { field: "quantity", title: resourceHelper.resolve("store.viewOrder.orderItems.quantity")},
                { field: "totalPrice", title: resourceHelper.resolve("store.viewOrder.orderItems.totalPrice")},
                { field: "comment", title: resourceHelper.resolve("store.viewOrder.orderItems.comment")}
            ],
            data: ctr.model
        };
    }
}