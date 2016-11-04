import {KeyNamePair} from "../../../common/models/keyNamePair";
import {ItemStatus} from "../../../common/enum";
export class Model {
    public id: string = String.empty;
    public name: string = String.empty;
    public description: string = String.empty;
    public status: ItemStatus = ItemStatus.Active;
    public price: number = 0;
    public fromDate: Date = null;
    public toDate: Date = null;
    public photos: Array<string> = [];
    public category: any = { id: "" };
    public import(item: any) {
        this.id = item.id;
        this.name = item.name;
        this.status = item.status;
        this.description = item.description;
        this.price = item.price;
        this.fromDate = item.fromDate;
        this.toDate = item.toDate;
        if (item.category) {
            this.category.id = item.category.id;
        }

        this.photos = item.photos;
    }
}