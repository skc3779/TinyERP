import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./createRequestModel";
import {SelectPermission, Page} from "../../../common/directive";
import {FormStatusToggle, FormSelect, Form, FormTextInput, FormFooter, FormTextArea, FormEmailInput} from "../../../common/directive";
import supportService from "../_share/services/supportService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";
import configHelper from "../../../common/helpers/configHelper";

@Component({
    templateUrl: "app/modules/support/request/createRequest.html",
    directives: [FormStatusToggle, FormSelect, Page, Form, FormTextInput, FormFooter, FormTextArea, FormEmailInput]
})
export class CreateRequest extends BasePage {
    public model: Model = new Model();
    private router: Router;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self = this;
        self.router = router;
    }
    public onSendClicked(event: any): void {
        let self = this;
        supportService.createRequest(this.model).then(function () {
            self.router.navigate(["Login"]);
        });
    }
    public onCancelClicked(event: any): void {
        let self = this;
        self.router.navigate([configHelper.getAppConfig().loginUrl]);
    }

}