using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Support;
using System.Net;
using System.Web.Http;
namespace App.Api.Features.Support
{
    [RoutePrefix("api/support/requests")]
    public class RequestsController : ApiController
    {
        [HttpPost]
        [Route("")]
        public IResponseData<string> CreateRequest(CreateRequest request) {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IRequestService service = IoC.Container.Resolve<IRequestService>();
                service.CreateRequest(request);
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
