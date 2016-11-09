import { Component } from "angular2/core";
import { Input } from "angular2/core";
import { BaseControl } from "../../../../common/models/ui";
import { Model } from "./orderItemsModel";
import { Grid, PageActions, Page, } from "../../../../common/directive";
@Component({
    selector: "order-items",
    templateUrl: "app/modules/store/_share/directives/orderItems.html",
    directives: [Grid, PageActions, Page]
})
export class OrderItems extends BaseControl {
    @Input() model: Array<any> = [];
    private viewModel: Model;
    constructor() {
        super();
        let self = this;
        self.viewModel = new Model(self.i18nHelper, self);
    }
    protected onChange() {
        this.viewModel.import(this.model);
    }
}