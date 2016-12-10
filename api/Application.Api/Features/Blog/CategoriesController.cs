namespace App.Api.Features.Blog
{
    using App.Common.DI;
    using App.Common.Http;
    using App.Common.Validation;
    using Service.Blog;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Http;

    [RoutePrefix("api/blog/categories")]
    public class CategoriesController : ApiController
    {
        [Route("")]
        [HttpGet()]
        public IResponseData<CategoryListItem> GetCategories() {
            IResponseData<CategoryListItem> response = new ResponseData<CategoryListItem>();
            try
            {
                IBlogCategoryService service = IoC.Container.Resolve<IBlogCategoryService>();
                IList<CategoryListItem> items = service.GetCategories();
            }
            catch (ValidationException ex) {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
    }
}