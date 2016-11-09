import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./viewOrderModel";
import {FormLabel} from "../../../common/directive";
import {Form, FormStatusToggle, FormSelect, Page} from "../../../common/directive";
import storeService from "../_share/services/storeService";
import {FormMode, Guid, FormLabelType} from "../../../common/enum";
import route from "../_share/config/route";
import {OrderItems} from "../_share/directives/orderItems";
import {OrderContact} from "../_share/directives/orderContact";
import {OrderStatus} from "../_share/models/enum";

@Component({
    templateUrl: "app/modules/store/order/viewOrder.html",
    directives: [Page, Form, OrderItems, OrderContact, FormLabel]
})
export class ViewOrder extends BasePage {
    public FormLabelType: any = FormLabelType;
    public model: Model = new Model();
    private router: Router;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self  = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.itemId = routeParams.get("id");
            storeService.getOrderSummary(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public getOrderStatus(status: any){
        let key = OrderStatus[status];
        key = String.firstCharToLower(key);
        return this.i18nHelper.resolve(String.format("store.orders.status.{0}", key));
    }
}