import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {Model} from "./storesModel";
import storeService from "../_share/services/storeService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/store/store/stores.html",
    directives: [Grid, PageActions, Page]
})
export class Stores extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self = this;
        self.router = router;
        self.model = new Model(self.i18nHelper);
        self.load();
        this.model.addPageAction(new PageAction("btnAddStore", "store.stores.addStoreAction", () => self.onAddNewItemClicked()));
    }
    private onAddNewItemClicked() {
        this.router.navigate([route.store.addStore.name]);
    }
    public onEditItemClicked(event: any) {
        this.router.navigate([route.store.editStore.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        let self = this;
        storeService.deleteStore(event.item.id).then(function () {
            self.load();
        });
    }
    private load() {
        let self = this;
        storeService.getStores().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}