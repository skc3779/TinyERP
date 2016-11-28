import { Component } from "angular2/core";
import { BasePage } from "../../../common/models/ui";
import { Router, RouteParams } from "angular2/router";
import { Page, Form, FormTextInput, FormFooter, FormTextArea } from "../../../common/directive";
import { FormMode } from "../../../common/enum";
import route from "../_share/config/route";
import { Model } from "./addOrUpdateCategoryModel";
import categoryService from "../_share/services/categoryService";
@Component({
    templateUrl: "app/modules/inventory/category/addOrUpdateCategory.html",
    directives: [Page, Form, FormTextInput, FormFooter, FormTextArea]
})
export class AddOrUpdateCategory extends BasePage {
    public model: Model = new Model();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    private itemId: String = String.empty;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddOrUpdateCategory = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");
            categoryService.getCategoryById(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onSaveClicked(event: any): void {
        let self: AddOrUpdateCategory = this;
        if (!self.model.validate()) { return; }
        if (self.mode === FormMode.Edit) {
            categoryService.updateCategory(this.model).then(function () {
                self.router.navigate([route.inventory.categories.name]);
            });
             return;
        }
        categoryService.createCategory(this.model).then(function () {
            self.router.navigate([route.inventory.categories.name]);
        });
    }
    public onCancelClicked(event: any): void {
        let self: AddOrUpdateCategory = this;
        self.router.navigate([route.inventory.categories.name]);
    }
}

