import configHelper from "../../../../common/helpers/configHelper";
import { Promise } from "../../../../common/models/promise";
let storeService = {
    getAccounts: getAccounts,
    deleteAccount: deleteAccount,
    getAccount: getAccount,
    createAccount: createAccount,
    updateAccount: updateAccount,

    getStores: getStores,
    deleteStore: deleteStore,
    createStore: createStore,
    getStore: getStore,
    updateStore: updateStore,

    getOrders: getOrders,
    getOrderSummary: getOrderSummary
};
export default storeService;
function getOrderSummary(itemId: string) {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}orders/{1}", configHelper.getAppConfig().api.baseUrl, itemId);
    return connector.get(url);
}
function getOrders(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}orders", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}

function getAccounts(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}accounts", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}

function deleteAccount(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}accounts/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}

function updateAccount(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}accounts/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function getAccount(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}accounts/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function createAccount(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}accounts", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}


function getStores(): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}stores", configHelper.getAppConfig().api.baseUrl);
    return connector.get(url);
}

function deleteStore(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}stores/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.delete(url);
}
function updateStore(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}stores/{1}", configHelper.getAppConfig().api.baseUrl, item.id);
    return connector.put(url, item);
}
function getStore(id: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}stores/{1}", configHelper.getAppConfig().api.baseUrl, id);
    return connector.get(url);
}
function createStore(item: any): Promise {
    let connector = window.ioc.resolve("IConnector");
    let url = String.format("{0}stores", configHelper.getAppConfig().api.baseUrl);
    return connector.post(url, item);
}


