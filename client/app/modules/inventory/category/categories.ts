import { Component } from "angular2/core";
import { BasePage } from "../../../common/models/ui";
import { Grid, PageActions, Page } from "../../../common/directive";
import { CategoriesModel } from "./categoriesModel";
import { PageAction } from "../../../common/models/ui";
import categoryService from "../_share/services/categoryService";

@Component({
    selector: "categories",
    templateUrl: "app/modules/inventory/category/categories.html",
    directives: [Grid, PageActions, Page]
})

export class Categories extends BasePage {
    public model: CategoriesModel;
    constructor() {
        super();
        let self: Categories = this;
        self.model = new CategoriesModel(self.i18nHelper);
        self.model.addPageAction(new PageAction("btnAddCategory", "inventory.categories.addCategoryAction", () => self.onAddNewCategoryClicked()));
        self.loadCategories();
    }

    private onAddNewCategoryClicked() {
        console.log("execute add new category funtion");
    }

    private onCategoryDeleteClicked(categoryItem: any) {
        let self: Categories = this;
        categoryService.deleteCategory(categoryItem.item.id).then(function () {
            self.loadCategories();
        });
    }

    private onCategoryEditClicked(event: any) {
        console.log("execute edit category funtion");

    }

    private loadCategories() {
        let self: Categories = this;
        categoryService.getCategories().then(function (items: Array<any>) {
            self.model.importCategories(items);
        });
    }
}