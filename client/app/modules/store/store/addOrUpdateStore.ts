import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./addOrUpdateStoreModel";
import {SelectPermission} from "../../../common/directive";
import {ValidationDirective, FormStatusToggle, FormSelect, Page} from "../../../common/directive";
import storeService from "../_share/services/storeService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";
import {StoreStatus} from "../_share/models/enum";

@Component({
    templateUrl: "app/modules/store/store/addOrUpdateStore.html",
    directives: [ValidationDirective, FormStatusToggle, FormSelect, Page]
})
export class AddOrUpdateStore extends BasePage {
    public StoreStatus: any = StoreStatus;
    public model: Model = new Model();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: any;
    public getOwnersFunc: any = storeService.getAccounts;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            storeService.getStore(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onOwnerChanged(values: Array<string>) {
        this.model.owner.id = values.firstOrDefault((val: string) => { return !String.isNullOrWhiteSpace(val) && val !== Guid.Empty; });
    }
    public onSaveClicked(event: any): void {
        let self = this;
        if (self.mode === FormMode.AddNew) {
            storeService.createStore(this.model).then(function () {
                self.router.navigate([route.store.stores.name]);
            });
            return;
        }
        storeService.updateStore(this.model).then(function () {
            self.router.navigate([route.store.stores.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self = this;
        self.router.navigate([route.store.stores.name]);
    }

}