using System.Collections.Generic;
using System.Web.Http;
using App.Common.Http;
using App.Common.Validation;
using App.Common.DI;
using App.Service.Inventory;

namespace App.Api.Features.Inventory
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<CategoryListItem>> GetProductCategories()
        {
            IResponseData<IList<CategoryListItem>> dataResponse = new ResponseData<IList<CategoryListItem>>();
            try
            {
                IProductCategoryService productCategoryService = IoC.Container.Resolve<IProductCategoryService>();
                IList<CategoryListItem> items = productCategoryService.GetProductCategories();
                dataResponse.SetData(items);
            }
            catch (ValidationException exception)
            {
                dataResponse.SetErrors(exception.Errors);
                dataResponse.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return dataResponse;
        }
    }
}
