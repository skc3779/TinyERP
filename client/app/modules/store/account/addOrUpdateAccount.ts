import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./addOrUpdateAccountModel";
import {Page, SelectPermission} from "../../../common/directive";
import {ValidationDirective, FormStatusToggle, FormSelect} from "../../../common/directive";
import storeService from "../_share/services/storeService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";

@Component({
    templateUrl: "app/modules/store/account/addOrUpdateAccount.html",
    directives: [ValidationDirective, FormStatusToggle, FormSelect, Page]
})
export class AddOrUpdateAccount extends BasePage {
    public model: Model = new Model();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddOrUpdateAccount = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            storeService.getAccount(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onSaveClicked(event: any): void {
        let self: AddOrUpdateAccount = this;
        if (self.mode === FormMode.AddNew) {
            storeService.createAccount(this.model).then(function () {
                self.router.navigate([route.store.accounts.name]);
            });
            return;
        }
        storeService.updateAccount(this.model).then(function () {
            self.router.navigate([route.store.accounts.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self: AddOrUpdateAccount = this;
        self.router.navigate([route.store.accounts.name]);
    }

}