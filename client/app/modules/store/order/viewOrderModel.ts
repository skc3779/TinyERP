import { KeyNamePair } from "../../../common/models/keyNamePair";
import { OrderStatus } from "../_share/models/enum";
export class Model {
    public id: string = String.empty;
    public price: number;
    public numberOfItems: number;
    public status: OrderStatus;
    public transactionDate: Date;
    public comment: string = String.empty;
    public contact: OrderContact = new OrderContact(null);
    public items: Array<OrderItem> = [];
    public import(item: any) {
        this.id = item.id;
        this.price = item.price;
        this.numberOfItems = item.numberOfItems;
        this.status = item.status;
        this.transactionDate = item.transactionDate;
        this.comment = item.comment;
        if (item.contact) {
            this.contact = new OrderContact(item.contact);
        }
        if (item.items) {
            this.items = this.getOrderItems(item.items);
        }
    }
    private getOrderItems(items: Array<any>): Array<OrderItem> {
        let result: Array<any> = [];
        if (!items || items.length <= 0) { return result; }
        items.forEach(function (item: any) {
            result.push(new OrderItem(item));
        });
        return result;
    }
}
export class OrderItem {
    public product: any = {};
    public quantity: number;
    public totalPrice: number;
    public comment: string;
    constructor(item: any) {
        if (!item) { return; }
        this.product = item.product;
        this.quantity = item.quantity;
        this.totalPrice = item.totalPrice;
        this.comment = item.comment;
    }
}
export class OrderContact {
    public name: string;
    public email: string;
    public phone: string;
    constructor(item: any) {
        if (!item) { return; }
        this.name = item.name;
        this.email = item.email;
        this.phone = item.phone;
    }
}