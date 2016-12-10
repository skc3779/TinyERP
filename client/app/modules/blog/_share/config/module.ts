import { IModule, Module, MenuItem } from "../../../../common/models/layout";
import { AuthenticationMode } from "../../../../common/enum";
import route from "./route";
import { Categories } from "../../category/categories";
let module: IModule = createModule();
export default module;
function createModule() {
    let module = new Module("app/modules/blog", "Blog");
    module.menus.push(
        new MenuItem(
            "Blog", route.blog.categories.name, "fa fa-cogs",
            new MenuItem("Categories", route.blog.categories.name, "")
        )
    );
    module.addRoutes([
        { path: route.blog.categories.path, name: route.blog.categories.name, component: Categories, data: { authentication: AuthenticationMode.Require } },
    ]);
    return module;
}
