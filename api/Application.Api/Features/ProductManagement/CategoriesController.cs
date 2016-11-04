using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.ProductManagement.Category;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace App.Api.Features.ProductManagement
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<CategoryListItem>> GetCategories()
        {
            IResponseData<IList<CategoryListItem>> response = new ResponseData<IList<CategoryListItem>>();
            try
            {
                ICategoryService service = IoC.Container.Resolve<ICategoryService>();
                IList<CategoryListItem> items = service.GetCategories();
                response.SetData(items);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public IResponseData<GetCategoryResponse> GetCategory(Guid id)
        {
            IResponseData<GetCategoryResponse> response = new ResponseData<GetCategoryResponse>();
            try
            {
                ICategoryService service = IoC.Container.Resolve<ICategoryService>();
                GetCategoryResponse item = service.Get(id);
                response.SetData(item);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpPost]
        [Route("")]
        public IResponseData<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request)
        {
            IResponseData<CreateCategoryResponse> response = new ResponseData<CreateCategoryResponse>();
            try
            {
                ICategoryService service = IoC.Container.Resolve<ICategoryService>();
                CreateCategoryResponse item = service.Create(request);
                response.SetData(item);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public IResponseData<string> UpdateCategory(Guid id, UpdateCategoryRequest request)
        {
            request.Id = id;
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                ICategoryService service = IoC.Container.Resolve<ICategoryService>();
                service.Update(request);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public IResponseData<string> DeleteCategory(Guid id)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                ICategoryService service = IoC.Container.Resolve<ICategoryService>();
                service.Delete(id);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
    }
}
