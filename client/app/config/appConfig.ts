import { IModule } from "../common/models/layout";
import registration from "../modules/registration/_share/config/module";
import securiry from "../modules/security/_share/config/module";
import setting from "../modules/setting/_share/config/module";
import support from "../modules/support/_share/config/module";
import inventory from "../modules/inventory/_share/config/module";
import blog from "../modules/blog/_share/config/module";
import { Languages } from "../common/enum";
let modules: Array<IModule> = [
    registration,
    securiry,
    setting,
    support,
    inventory,
    blog
];
export default {
    app: {
        name: "myERP"
    },
    ioc: "./config/ioc",
    modules: modules,
    loginUrl: "/Login",
    defaultUrl: "Roles",
    localization: {
        lang: Languages.EN,
        files: ["common", "registration", "security", "productManagement", "store", "setting", "support", "inventory", "blog"]
    },
    auth: {
        token: "authtoken"
    },
    api: {
        baseUrl: "http://localhost:22383/api/"
    },
    localeUrl: "/app/resources/locales/"
};