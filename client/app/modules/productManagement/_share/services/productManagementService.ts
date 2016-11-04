import configHelper from "../../../../common/helpers/configHelper";
import {Promise} from "../../../../common/models/promise";
let pmService = {
    getCategories: getCategories,
    deleteCategory: deleteCategory,
    createCategory: createCategory,
    getCategory: getCategory,
    updateCategory: updateCategory,

    getProducts: getProducts,
    deleteProduct: deleteProduct,
    createProduct: createProduct,
    getProduct: getProduct,
    updateProduct: updateProduct,
};
export default pmService;
/*Product*/
function getProducts(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}products", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}

function deleteProduct(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}products/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}
function updateProduct(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}products/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function getProduct(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}products/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function createProduct(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}products", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}
/*End of Products */
function getCategories(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}categories", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}

function deleteCategory(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}categories/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}
function updateCategory(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}categories/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function getCategory(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}categories/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function createCategory(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}categories", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}