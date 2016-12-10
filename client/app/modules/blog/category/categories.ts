import { Component } from "angular2/core";
import { BasePage } from "../../../common/models/ui";
import { Grid, PageActions, Page } from "../../../common/directive";
import { CategoriesModel } from "./categoriesModel";
import { PageAction } from "../../../common/models/ui";
import blogService from "../_share/services/blogService";
import { Router } from "angular2/router";
import route from "../_share/config/route";
import { ErrorMessage } from "../../../common/layouts/default/directives/common/errorMessage";
@Component({
    templateUrl: "app/modules/blog/category/categories.html",
    directives: [Grid, PageActions, Page, ErrorMessage]
})
export class Categories extends BasePage {
    public model: CategoriesModel;
    public router: Router;
    constructor(router: Router) {
        super();
        let self: Categories = this;
        self.router = router;
        self.model = new CategoriesModel(self.i18nHelper);
        self.model.addPageAction(new PageAction("btnAddCategory", "blog.categories.addCategoryAction", () => self.onAddNewCategoryClicked()));
        self.loadCategories();
    }
    private onAddNewCategoryClicked() {
        //this.router.navigate([route.blog.addCategory.name]);
    }

    private onCategoryDeleteClicked(categoryItem: any) {
        let self: Categories = this;
        blogService.deleteCategory(categoryItem.item.id).then(function () {
            self.loadCategories();
        });
    }
    private onCategoryEditClicked(event: any) {
        //this.router.navigate([route.inventory.updateCategory.name, { id: event.item.id }]);
    }
    private loadCategories() {
        let self: Categories = this;
        blogService.getCategories().then(function (items: Array<any>) {
            self.model.importCategories(items);
        });
    }
}