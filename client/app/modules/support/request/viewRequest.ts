import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Model} from "./viewRequestModel";
import {SelectPermission, Page, PageActions} from "../../../common/directive";
import {ValidationDirective, FormStatusToggle, FormSelect, Form, FormTextInput, FormFooter, FormTextArea, FormDatetime} from "../../../common/directive";
import supportService from "../_share/services/supportService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";

@Component({
    templateUrl: "app/modules/support/request/viewRequest.html",
    directives: [ValidationDirective, FormStatusToggle, FormSelect, Page, PageActions, Form, FormTextInput, FormFooter, FormTextArea, FormDatetime]
})
export class ViewRequest extends BasePage {
    public model: Model = new Model(this);
    private router: Router;
    private itemId: any;
    constructor(router: Router, routeParams: RouteParams) {
        super();
        let self = this;
        self.router = router;
        if (!!routeParams.get("id")) {
            self.itemId = routeParams.get("id");
            supportService.getRequest(self.itemId).then(function (item: any) {
                self.model.import(item);
            });
        }
    }
    public onMarkAsResolvedClicked(model: any) {
        let self = this;
        supportService.markRequestAsResolved(model.id).then(function () {
            self.router.navigate([route.support.requests.name]);
        });
    }
    public onCancelRequestClicked(model: any) {
        let self = this;
        supportService.cancelRequest(model.id).then(function () {
            self.router.navigate([route.support.requests.name]);
        });
    }
}