import configHelper from "../../../../common/helpers/configHelper";
import { Promise } from "../../../../common/models/promise";
import { IoCNames } from "../../../../common/enum";
let addOrUpdateCategoryService = {
    get: get,
    update: update
};
export default addOrUpdateCategoryService;
function get(id: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}inventory/categories/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function update(item: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}inventory/categories/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
