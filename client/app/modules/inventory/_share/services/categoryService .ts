import configHelper from "../../../../common/helpers/configHelper";
import { Promise } from "../../../../common/models/promise";
import { IoCNames } from "../../../../common/enum";
let categoryService = {
    getCategoryById: getCategoryById,
    updateCategory: updateCategory,
    addNewCategory: addNewCategory
};
export default categoryService;
function getCategoryById(id: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}inventory/categories/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function updateCategory(item: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}inventory/categories/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function addNewCategory(item: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}inventory/categories", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}