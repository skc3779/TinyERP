import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {Model} from "./accountsModel";
import storeService from "../_share/services/storeService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/store/account/accounts.html",
    directives: [Grid, PageActions, Page]
})
export class Accounts extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self: Accounts = this;
        self.router = router;
        self.model = new Model(self.i18nHelper);
        self.load();
        this.model.addPageAction(new PageAction("btnAddPer", "store.accounts.addAccountAction", () => self.onAddNewItemClicked()));
    }
    private onAddNewItemClicked() {
        this.router.navigate([route.store.addAccount.name]);
    }
    public onEditItemClicked(event: any) {
        this.router.navigate([route.store.editAccount.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        let self: Accounts = this;
        storeService.deleteAccount(event.item.id).then(function () {
            self.load();
        });
    }
    private load() {
        let self: Accounts = this;
        storeService.getAccounts().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}