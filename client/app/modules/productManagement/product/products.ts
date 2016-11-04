import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {Model} from "./productsModel";
import pmService from "../_share/services/productManagementService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/productManagement/product/products.html",
    directives: [Grid, PageActions, Page]
})
export class Products extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self: Products = this;
        self.router = router;
        self.model = new Model(self.i18nHelper);
        self.load();
        this.model.addPageAction(new PageAction("btnAddPer", "productManagement.products.addProductAction", () => self.onAddNewItemClicked()));
    }
    private onAddNewItemClicked() {
        this.router.navigate([route.productManagement.addProduct.name]);
    }
    public onEditItemClicked(event: any) {
        this.router.navigate([route.productManagement.editProduct.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        let self: Products = this;
        pmService.deleteProduct(event.item.id).then(function () {
            self.load();
        });
    }
    private load() {
        let self: Products = this;
        pmService.getProducts().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}