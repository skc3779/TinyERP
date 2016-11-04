import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./addOrUpdateCategoryModel";
import {SelectPermission} from "../../../common/directive";
import {ValidationDirective, FormStatusToggle, FormSelect, Page} from "../../../common/directive";
import pmService from "../_share/services/productManagementService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";

@Component({
    templateUrl: "app/modules/productManagement/category/addOrUpdateCategory.html",
    directives: [ValidationDirective, FormStatusToggle, FormSelect, Page]
})
export class AddOrUpdateCategory extends BasePage {
    public model: Model = new Model();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    public getItemsFunc: any = pmService.getCategories;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddOrUpdateCategory = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            pmService.getCategory(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onParentChanged(values: Array<string>) {
        this.model.parentId = values.firstOrDefault((val: string) => { return !String.isNullOrWhiteSpace(val) && val !== Guid.Empty; });
    }
    public onSaveClicked(event: any): void {
        let self: AddOrUpdateCategory = this;
        if (self.mode === FormMode.AddNew) {
            pmService.createCategory(this.model).then(function () {
                self.router.navigate([route.productManagement.categories.name]);
            });
            return;
        }
        pmService.updateCategory(this.model).then(function () {
            self.router.navigate([route.productManagement.categories.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self: AddOrUpdateCategory = this;
        self.router.navigate([route.productManagement.categories.name]);
    }

}