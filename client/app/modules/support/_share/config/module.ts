import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {AuthenticationMode} from "../../../../common/enum";

import {CreateRequest} from "../../request/createRequest";
import {CreateRequestConfirmation} from "../../request/createRequestConfirmation";
import route from "./route";

let module: IModule = createModule();
export default module;
function createModule() {
    let module = new Module("app/modules/support", "support");
    module.menus.push(
        new MenuItem(
            "Request", route.support.createRequest.name, "fa fa-cogs",
            new MenuItem("ContentTypes", route.support.createRequest.name, "")
        )
    );
    module.addRoutes([
        { path: route.support.createRequest.path, name:  route.support.createRequest.name, component: CreateRequest, data: { authentication: AuthenticationMode.None }},
        { path: route.support.createRequestConfirmation.path, name:  route.support.createRequestConfirmation.name, component: CreateRequestConfirmation, data: { authentication: AuthenticationMode.None }},
    ]);
    return module;
}