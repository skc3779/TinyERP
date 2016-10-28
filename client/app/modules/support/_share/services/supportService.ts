import configHelper from "../../../../common/helpers/configHelper";
import { Promise } from "../../../../common/models/promise";
import { IoCNames } from "../../../../common/enum";
let supportService = {
    createRequest: createRequest,
    getRequests: getRequests,
    getRequest: getRequest
};
export default supportService;
function createRequest(model: any) {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}support/requests", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, model);
}
function getRequests() {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}support/requests", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}
function getRequest(itemId: string) {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}support/requests/{1}", configHelper.getAppConfig().api.baseUrl, itemId);
    return connector.get(url);
}