import { Component, Input } from "angular2/core";
import { BaseControl } from "../../../../common/models/ui";
import { Page, Form, FormLabel } from "../../../../common/directive";
@Component({
    selector: "order-contact",
    templateUrl: "app/modules/store/_share/directives/orderContact.html",
    directives: [Page, Form, FormLabel]
})
export class OrderContact extends BaseControl {
    @Input() model: any = {};
}