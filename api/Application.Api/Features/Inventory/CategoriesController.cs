namespace App.Api.Features.Inventory
{
    using System.Collections.Generic;
    using System.Web.Http;
    using App.Common.Http;
    using App.Common.Validation;
    using App.Common.DI;
    using App.Service.Inventory;
    using System.Net;
    using System;

    [RoutePrefix("api/inventory/categories")]
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

        [Route("{id}")]
        [HttpGet]
        public IResponseData<GetCategoryResponse> GetById([FromUri]string id)
        {
            IResponseData<GetCategoryResponse> response = new ResponseData<GetCategoryResponse>();
            try
            {
                ICategoryService categoryService = IoC.Container.Resolve<ICategoryService>();
                GetCategoryResponse item = categoryService.GetById(id);
                response.SetData(item);
            }
            catch (ValidationException exception)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(exception.Errors);
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
                ICategoryService categorytService = IoC.Container.Resolve<ICategoryService>();
                categorytService.Create(request);
            }
            catch (ValidationException exception)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(exception.Errors);
            }

            return response;
        }

        [Route("{id}")]
        [HttpPut]
        public IResponseData<string> UpdateCategory([FromUri]Guid id, [FromBody]UpdateCategoryRequest request)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                request.Id = id;
                ICategoryService categoryService = IoC.Container.Resolve<ICategoryService>();
                categoryService.Update(request);
            }
            catch (ValidationException exception)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(exception.Errors);
            }

            return response;
        }
    }
}