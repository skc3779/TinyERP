import { ItemStatus } from "../../../common/enum";
import { IoCNames } from "../../../common/enum";
export class Model {
    public options: any = {};
    public eventKey: string = "requests_ondatasource_changed";
    constructor(ctr: any, resourceHelper: any) {
        this.options = {
            columns: [
                { field: "subject", title: resourceHelper.resolve("support.requests.grid.subject") },
                { field: "email", title: resourceHelper.resolve("support.requests.grid.email") },
                {
                    field: "status", title: resourceHelper.resolve("support.requests.grid.status"),
                    render: function (data: any) {
                        return data === ItemStatus.Resolved ? resourceHelper.resolve("common.form.status.resolved") : resourceHelper.resolve("common.form.status.new");
                    }
                }
            ],
            actions: [
                { text: resourceHelper.resolve("common.form.view"), handler: (item: any) => ctr.onViewItemClicked(item) }
    ],
            data: []
        };
    }
    public import(items: Array<any>) {
        let eventManager = window.ioc.resolve(IoCNames.IEventManager);
        eventManager.publish(this.eventKey, items);
    }
}