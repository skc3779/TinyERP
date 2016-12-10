import { Promise } from "../../../../common/models/promise";
import { IoCNames } from "../../../../common/enum";
import configHelper from "../../../../common/helpers/configHelper";
let blogService={
    deleteCategory: deleteCategory,
    getCategories: getCategories
};
export default blogService;
function getCategories(){
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}blog/categories", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function deleteCategory(itemId: string){
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}blog/categories/{1}", configHelper.getAppConfig().api.baseUrl, itemId);
    return connector.get(url);
}