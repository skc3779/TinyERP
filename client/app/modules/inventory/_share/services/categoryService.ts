import { Promise } from "../../../../common/models/promise";
import { IoCNames } from "../../../../common/enum";
import configHelper from "../../../../common/helpers/configHelper";

let categoryService = {
    getCategories: getCategories
};
export default categoryService;

function getCategories(): Promise {
    let connector = window.ioc.resolve(IoCNames.IConnector);
    let url = String.format("{0}categories", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}