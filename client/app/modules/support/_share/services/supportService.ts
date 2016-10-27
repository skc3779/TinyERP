import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";
import {IoCNames} from "../../../../common/enum";
let supportService ={
    createRequest:createRequest
};
export default supportService;
function createRequest(model: any){
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}support/requests", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, model);
}