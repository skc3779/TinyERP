using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Store.Store;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace App.Api.Features.Store
{
    [RoutePrefix("api/stores")]
    public class StoresController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<StoreListItem>> GetStores()
        {
            IResponseData<IList<StoreListItem>> response = new ResponseData<IList<StoreListItem>>();
            try
            {
                IStoreService service = IoC.Container.Resolve<IStoreService>();
                IList<StoreListItem> items = service.GetStores();
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
        public IResponseData<string> DeleteStore(Guid id)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IStoreService service = IoC.Container.Resolve<IStoreService>();
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
        public IResponseData<GetStoreResponse> GetStore(Guid id)
        {
            IResponseData<GetStoreResponse> response = new ResponseData<GetStoreResponse>();
            try
            {
                IStoreService service = IoC.Container.Resolve<IStoreService>();
                GetStoreResponse item = service.Get(id);
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
        public IResponseData<CreateStoreResponse> CreateStore(CreateStoreRequest request)
        {
            IResponseData<CreateStoreResponse> response = new ResponseData<CreateStoreResponse>();
            try
            {
                IStoreService service = IoC.Container.Resolve<IStoreService>();
                CreateStoreResponse item = service.Create(request);
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
        public IResponseData<string> UpdateAccount(Guid id, UpdateStoreRequest request)
        {
            request.Id = id;
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IStoreService service = IoC.Container.Resolve<IStoreService>();
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
