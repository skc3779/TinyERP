import { Component, Input } from "angular2/core";
import { BaseControl } from "../../../../common/models/ui";
@Component({
    templateUrl: "app/modules/store/_share/directives/orderContact.html"
})
export class OrderContact extends BaseControl {
    @Input() model: any = {};
}