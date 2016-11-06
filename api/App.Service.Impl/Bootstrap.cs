using App.Common.DI;
namespace App.Service.Impl
{
    public class Bootstrap : App.Common.Tasks.BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap():base(App.Common.ApplicationType.All)
        {

        }
        public void Execute(IBaseContainer context)
        {
            context.RegisterSingleton<App.Service.Registration.User.IUserService, App.Service.Impl.Registration.UserService>();
            context.RegisterSingleton<App.Service.Common.ILanguageService, App.Service.Impl.Common.LanguageService>();
            context.RegisterSingleton<App.Service.Security.IRoleService, App.Service.Impl.Security.RoleService>();
            context.RegisterSingleton<App.Service.Security.IPermissionService, App.Service.Impl.Security.PermissionService>();
            context.RegisterSingleton<App.Service.Security.IUserGroupService, App.Service.Impl.Security.UserGroupService>();

            context.RegisterSingleton<App.Service.Common.File.IFileService, App.Service.Impl.Common.FileService>();
            context.RegisterSingleton<App.Service.Setting.IContentTypeService, App.Service.Impl.Setting.ContentTypeService>();
            context.RegisterSingleton<App.Service.Support.IRequestService, App.Service.Impl.Support.RequestService>();

            //Store
            context.RegisterSingleton<App.Service.Store.Store.IStoreService, App.Service.Impl.Store.StoreService>();
            context.RegisterSingleton<App.Service.Store.Order.IOrderService, App.Service.Impl.Store.OrderService>();
            context.RegisterSingleton<App.Service.Store.IAccountService, App.Service.Impl.Store.AccountService>();

            //Product
            context.RegisterSingleton<App.Service.ProductManagement.Category.ICategoryService, App.Service.Impl.ProductManagement.CategoryService>();
            context.RegisterSingleton<App.Service.ProductManagement.Product.IProductService, App.Service.Impl.ProductManagement.ProductService>();
        }
    }
}
