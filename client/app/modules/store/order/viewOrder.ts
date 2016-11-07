import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./viewOrderModel";
import {SelectPermission} from "../../../common/directive";
import {ValidationDirective, FormStatusToggle, FormSelect, Page} from "../../../common/directive";
import storeService from "../_share/services/storeService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";
import {OrderItems} from "../_share/directives/orderItems";
import {OrderContact} from "../_share/directives/orderContact";

@Component({
    templateUrl: "app/modules/store/order/viewOrder.html",
    directives: [Page, OrderItems, OrderContact]
})
export class ViewOrder extends BasePage {
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
}