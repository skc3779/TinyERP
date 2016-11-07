import { Component } from "angular2/core";
import { Router } from "angular2/router";
import { BasePage } from "../../../common/models/ui";
import { Model } from "./ordersModel";
import storeService from "../_share/services/storeService";
import { Grid, PageActions, Page } from "../../../common/directive";
import { PageAction } from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/store/order/orders.html",
    directives: [Grid, PageActions, Page]
})
export class Orders extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self = this;
        self.router = router;
        self.model = new Model(self.i18nHelper, self);
        self.load();
    }
    public onViewItemClicked(ev: any){
        this.router.navigate([route.store.viewOrder.name,{id:ev.item.id}]);
    }
    private load() {
        let self = this;
        storeService.getOrders().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}