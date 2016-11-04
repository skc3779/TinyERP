using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.ProductManagement.Product;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace App.Api.Features.ProductManagement
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<ProductListItem>> GetProducts()
        {
            IResponseData<IList<ProductListItem>> response = new ResponseData<IList<ProductListItem>>();
            try
            {
                IProductService service = IoC.Container.Resolve<IProductService>();
                IList<ProductListItem> items = service.GetProducts();
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
        public IResponseData<GetProductResponse> Get(Guid id)
        {
            IResponseData<GetProductResponse> response = new ResponseData<GetProductResponse>();
            try
            {
                IProductService service = IoC.Container.Resolve<IProductService>();
                GetProductResponse item = service.Get(id);
                response.SetData(item);
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
        public IResponseData<string> DeleteProduct(Guid id)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IProductService service = IoC.Container.Resolve<IProductService>();
                service.Delete(id);
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
        public IResponseData<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            IResponseData<CreateProductResponse> response = new ResponseData<CreateProductResponse>();
            try
            {
                IProductService service = IoC.Container.Resolve<IProductService>();
                CreateProductResponse item = service.Create(request);
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
        public IResponseData<string> UpdateProduct(Guid id, UpdateProductRequest request)
        {
            request.Id = id;
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IProductService service = IoC.Container.Resolve<IProductService>();
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
