import {BasePage} from "../../../common/models/ui";
import {Router, RouteParams} from "angular2/router";
import {Component} from "angular2/core";
import {Page} from "../../../common/directive";
import supportService from "../_share/services/supportService";
import {FormMode, Guid} from "../../../common/enum";
import route from "../_share/config/route";
import configHelper from "../../../common/helpers/configHelper";

@Component({
    templateUrl: "app/modules/support/request/createRequestConfirmation.html",
    directives: [Page]
})
export class CreateRequestConfirmation extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self = this;
        self.router = router;
    }
    public onGotoLoginClicked(event: any): void {
        let self = this;
        self.router.navigate([configHelper.getAppConfig().loginUrl]);
    }

}