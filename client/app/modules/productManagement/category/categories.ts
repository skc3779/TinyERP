import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {Model} from "./categoriesModel";
import pmService from "../_share/services/productManagementService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/productManagement/category/categories.html",
    directives: [Grid, PageActions, Page]
})
export class Categories extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self: Categories = this;
        self.router = router;
        self.model = new Model(self.i18nHelper);
        self.load();
        this.model.addPageAction(new PageAction("btnAddPer", "productManagement.categories.addCategoryAction", () => self.onAddNewItemClicked()));
    }
    private onAddNewItemClicked() {
        this.router.navigate([route.productManagement.addCategory.name]);
    }
    public onEditItemClicked(event: any) {
        this.router.navigate([route.productManagement.editCategory.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        let self: Categories = this;
        pmService.deleteCategory(event.item.id).then(function () {
            self.load();
        });
    }
    private load() {
        let self: Categories = this;
        pmService.getCategories().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}