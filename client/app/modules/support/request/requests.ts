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
    private routeConfig = route;
    constructor(router: Router) {
        super();
        let self = this;
        self.router = router;
        self.model = new Model(this, self.i18nHelper);
        self.load();
    }
    public onViewItemClicked(event: any){
        this.router.navigate([this.routeConfig.support.viewRequest.name, { id: event.item.id }]);
    }
    private load() {
        let self = this;
        supportService.getRequests().then(function (items: Array<any>) {
            self.model.import(items);
        });
    }
}