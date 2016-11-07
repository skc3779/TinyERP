import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {AuthenticationMode} from "../../../../common/enum";
import {Accounts} from "../../account/accounts";
import {AddOrUpdateAccount} from "../../account/addOrUpdateAccount";

import {Stores} from "../../store/stores";
import {AddOrUpdateStore} from "../../store/addOrUpdateStore";

import {Orders} from "../../order/orders";
import {ViewOrder} from "../../order/viewOrder";

import route from "./route";

let module: IModule = createModule();
export default module;
function createModule() {
    let module = new Module("app/modules/store", route.store.accounts.name);
    module.menus.push(
        new MenuItem(
            "Store", route.store.accounts.name, "fa fa-university",
            new MenuItem("Accounts", route.store.accounts.name, ""),
            new MenuItem("Stores", route.store.stores.name, ""),
            new MenuItem("Orders", route.store.orders.name, "")
        )
    );
    module.addRoutes([
        { path: route.store.accounts.path, name: route.store.accounts.name, component: Accounts, data: { authentication: AuthenticationMode.Require } },
        { path: route.store.addAccount.path, name: route.store.addAccount.name, component: AddOrUpdateAccount, data: { authentication: AuthenticationMode.Require } },
        { path: route.store.editAccount.path, name: route.store.editAccount.name, component: AddOrUpdateAccount, data: { authentication: AuthenticationMode.Require } },

        { path: route.store.stores.path, name: route.store.stores.name, component: Stores, data: { authentication: AuthenticationMode.Require } },
        { path: route.store.addStore.path, name: route.store.addStore.name, component: AddOrUpdateStore, data: { authentication: AuthenticationMode.Require } },
        { path: route.store.editStore.path, name: route.store.editStore.name, component: AddOrUpdateStore, data: { authentication: AuthenticationMode.Require } },

        { path: route.store.orders.path, name: route.store.orders.name, component: Orders, data: { authentication: AuthenticationMode.Require } },
        { path: route.store.viewOrder.path, name: route.store.viewOrder.name, component: ViewOrder, data: { authentication: AuthenticationMode.Require } }

    ]);
    return module;
}