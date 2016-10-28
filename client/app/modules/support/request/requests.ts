import {Component }  from "angular2/core";
import {Router} from "angular2/router";
import {BasePage} from "../../../common/models/ui";
import {Model} from "./requestsModel";
import supportService from "../_share/services/supportService";
import {Grid, PageActions, Page} from "../../../common/directive";
import {PageAction} from "../../../common/models/ui";
import route from "../_share/config/route";
@Component({
    templateUrl: "app/modules/support/request/requests.html",
    directives: [Grid, PageActions, Page]
})
export class Requests extends BasePage {
    private router: Router;
    constructor(router: Router) {
        super();
        let self = this;
        self.router = router;
        self.model = new Model(self.i18nHelper);
        self.load();
    }
    public onEditItemClicked(event: any) {
        //this.router.navigate([route.setting.editContentType.name, { id: event.item.id }]);
    }
    public onDeleteItemClicked(event: any) {
        // let self = this;
        // settingService.deleteContentType(event.item.id).then(function () {
        //     self.load();
        // });
    }
    private load() {
        let self = this;
        supportService.getRequests().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}