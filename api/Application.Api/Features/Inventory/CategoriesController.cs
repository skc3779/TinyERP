using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Inventory;
using System.Net;
using System.Web.Http;

namespace App.Api.Features.Inventory
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
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
