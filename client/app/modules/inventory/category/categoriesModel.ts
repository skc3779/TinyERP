import { IoCNames } from "../../../common/enum";

export class CategoriesModel {
    public options: any = {};
    public eventKey: string = "categories_onLoaded";
    public actions: Array<any> = [];
    constructor(resourceHelper: any) {
        this.options = {
            columns: [
                { field: "name", title: resourceHelper.resolve("inventory.categories.name"), index: 0 },
                { field: "description", title: resourceHelper.resolve("inventory.categories.description"), index: 1 },
            ],
            data: [],
            enableEdit: true,
            enableDelete: true,
        };
    }

    public addPageAction(action: any) {
        this.actions.push(action);
    }

    public importCategories(items: Array<any>) {
        let eventManager = window.ioc.resolve(IoCNames.IEventManager);
        eventManager.publish(this.eventKey, items);
    }
}