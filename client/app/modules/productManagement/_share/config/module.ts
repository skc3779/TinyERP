import {IModule, Module, MenuItem} from "../../../../common/models/layout";
import {AuthenticationMode} from "../../../../common/enum";
import {Categories} from "../../category/categories";
import {AddOrUpdateCategory} from "../../category/addOrUpdateCategory";

import {Products} from "../../product/products";
import {AddOrUpdateProduct} from "../../product/addOrUpdateProduct";
import route from "./route";

let module: IModule = createModule();
export default module;
function createModule() {
    let module = new Module("app/modules/productManagement", "productManagement");
    module.menus.push(
        new MenuItem(
            "Product Management", route.productManagement.categories.name, "fa fa-apple",
            new MenuItem("Categories", route.productManagement.categories.name, ""),
            new MenuItem("Products", route.productManagement.products.name, "")
        )
    );
    module.addRoutes([
        { path: route.productManagement.categories.path, name: route.productManagement.categories.name, component: Categories, data: { authentication: AuthenticationMode.Require } },
        { path: route.productManagement.addCategory.path, name: route.productManagement.addCategory.name, component: AddOrUpdateCategory, data: { authentication: AuthenticationMode.Require } },
        { path: route.productManagement.editCategory.path, name: route.productManagement.editCategory.name, component: AddOrUpdateCategory, data: { authentication: AuthenticationMode.Require } },

        { path: route.productManagement.products.path, name: route.productManagement.products.name, component: Products, data: { authentication: AuthenticationMode.Require } },
        { path: route.productManagement.addProduct.path, name: route.productManagement.addProduct.name, component: AddOrUpdateProduct, data: { authentication: AuthenticationMode.Require } },
        { path: route.productManagement.editProduct.path, name: route.productManagement.editProduct.name, component: AddOrUpdateProduct, data: { authentication: AuthenticationMode.Require } }

    ]);
    return module;
}