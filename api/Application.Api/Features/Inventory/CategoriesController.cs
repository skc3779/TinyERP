namespace App.Api.Features.Inventory
{
    using System.Collections.Generic;
    using System.Web.Http;
    using App.Common.Http;
    using App.Common.Validation;
    using App.Common.DI;
    using App.Service.Inventory;
    using System;
    using System.Net;

    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<CategoryListItem>> GetCategories()
        {
            IResponseData<IList<CategoryListItem>> dataResponse = new ResponseData<IList<CategoryListItem>>();
            try
            {
                ICategoryService categoryService = IoC.Container.Resolve<ICategoryService>();
                IList<CategoryListItem> items = categoryService.GetCategories();
                dataResponse.SetStatus(System.Net.HttpStatusCode.OK);
                dataResponse.SetData(items);
            }
            catch (ValidationException exception)
            {
                dataResponse.SetErrors(exception.Errors);
                dataResponse.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return dataResponse;
        }

        [HttpDelete]
        [Route("{id}")]
        public IResponseData<string> DeleteCategory([FromUri] Guid id)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                ICategoryService categoryService = IoC.Container.Resolve<ICategoryService>();
                categoryService.DeleteCategory(id);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }

            return response;
        }
    }
}
