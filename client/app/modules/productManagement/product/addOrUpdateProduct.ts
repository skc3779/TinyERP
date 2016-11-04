import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./addOrUpdateProductModel";
import {SelectPermission, Page} from "../../../common/directive";
import {ValidationDirective, FormDatePicker, FormStatusToggle, FormCurrency, FormWizard, FormWizardItem, FormFilesUpload, FormSelect} from "../../../common/directive";
import pmService from "../_share/services/productManagementService";
import {FormMode, Guid} from "../../../common/enum";
import configHelper from "../../../common/helpers/configHelper";
import guidHelper from "../../../common/helpers/guidHelper";
import route from "../_share/config/route";

@Component({
    templateUrl: "app/modules/productManagement/product/addOrUpdateProduct.html",
    directives: [ValidationDirective, FormDatePicker, FormStatusToggle, FormCurrency, FormWizard, FormWizardItem, FormFilesUpload, FormSelect, Page]
})
export class AddOrUpdateProduct extends BasePage {
    private itemId: any = guidHelper.create();
    public model: Model = new Model();
    private router: Router;
    private mode: FormMode = FormMode.AddNew;
    public fileUploadHandler: string;
    public getCategoriesFunc: any = pmService.getCategories;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self: AddOrUpdateProduct = this;
        self.model.id = this.id;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.mode = FormMode.Edit;
            self.itemId = routeParams.get("id");

            pmService.getProduct(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
        this.fileUploadHandler = String.format("{0}files/{1}", configHelper.getAppConfig().api.baseUrl, this.itemId);
    }
    public onCategoryChanged(values: Array<any>) {
        this.model.category.id = values.firstOrDefault((val: string) => { return !String.isNullOrWhiteSpace(val) && val !== Guid.Empty; });
    }
    public onCancelClicked(event: any): void {
        let self: AddOrUpdateProduct = this;
        self.router.navigate([route.productManagement.products.name]);
    }
    public onFinishClicked(event: any) {
        let self: AddOrUpdateProduct = this;
        if (self.mode === FormMode.AddNew) {
            pmService.createProduct(this.model).then(function () {
                self.router.navigate([route.productManagement.products.name]);
            });
            return;
        }
        pmService.updateProduct(this.model).then(function () {
            self.router.navigate([route.productManagement.products.name]);
        });
    }
}