import { Promise } from "../../../../common/models/promise";
import { IoCNames } from "../../../../common/enum";
import configHelper from "../../../../common/helpers/configHelper";

let categoryService = {
    getCategories: getCategories,
    getCategoryById: getCategoryById,
    updateCategory: updateCategory,
    addNewCategory: addNewCategory
};
export default categoryService;
function getCategories(): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}categories", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function getCategoryById(id: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}categories/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function updateCategory(item: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}categories/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function addNewCategory(item: any): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}categories", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}