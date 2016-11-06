using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Store;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace App.Api.Features.Store
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<AccountListItem>> GetAccounts()
        {
            IResponseData<IList<AccountListItem>> response = new ResponseData<IList<AccountListItem>>();
            try
            {
                IAccountService service = IoC.Container.Resolve<IAccountService>();
                IList<AccountListItem> items = service.GetAccounts();
                response.SetData(items);
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
                IAccountService service = IoC.Container.Resolve<IAccountService>();
                service.Delete(id);
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
        public IResponseData<GetAccountResponse> GetAccount(Guid id)
        {
            IResponseData<GetAccountResponse> response = new ResponseData<GetAccountResponse>();
            try
            {
                IAccountService service = IoC.Container.Resolve<IAccountService>();
                GetAccountResponse item = service.Get(id);
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
        public IResponseData<CreateAccountResponse> CreateAccount(CreateAccountRequest request)
        {
            IResponseData<CreateAccountResponse> response = new ResponseData<CreateAccountResponse>();
            try
            {
                IAccountService service = IoC.Container.Resolve<IAccountService>();
                CreateAccountResponse item = service.Create(request);
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
        public IResponseData<string> UpdateAccount(Guid id, UpdateAccountRequest request)
        {
            request.Id = id;
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IAccountService service = IoC.Container.Resolve<IAccountService>();
                service.Update(request);
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
