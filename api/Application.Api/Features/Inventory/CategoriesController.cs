namespace App.Api.Features.Inventory
{
    using System.Collections.Generic;
    using System.Web.Http;
    using App.Common.Http;
    using App.Common.Validation;
    using App.Common.DI;
    using App.Service.Inventory;
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

        [Route("{itemId}")]
        [HttpGet]
        public IResponseData<GetCategoryResponse> GetById([FromUri]string itemId)
        {
            IResponseData<GetCategoryResponse> response = new ResponseData<GetCategoryResponse>();
            try
            {
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                GetCategoryResponse item = catService.GetById(itemId);
                response.SetData(item);
            }
            catch (ValidationException ex)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(ex.Errors);
            }
            return response;
        }

        [Route("")]
        [HttpPost]
        public IResponseData<string> CreateCategory([FromBody]CreateCategoryRequest request)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                catService.Create(request);
            }
            catch (ValidationException ex)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(ex.Errors);
            }
            return response;
        }

        [Route("{itemId}")]
        [HttpPut]
        public IResponseData<GetCategoryResponse> UpdateCategory([FromUri]string itemId, [FromBody]UpdateCategoryRequest request)
        {
            IResponseData<GetCategoryResponse> response = new ResponseData<GetCategoryResponse>();
            try
            {
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                catService.Update(itemId, request);
                GetCategoryResponse item = catService.GetById(itemId);
                response.SetData(item);
            }
            catch (ValidationException ex)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(ex.Errors);
            }
            return response;
        }
    }
}

        
