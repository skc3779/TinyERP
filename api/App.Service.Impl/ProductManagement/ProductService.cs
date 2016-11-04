using System.Collections.Generic;
using App.Service.ProductManagement.Product;
using App.Common.DI;
using App.Repository.ProductManagement;
using System;
using App.Common.Data;
using App.Common;
using App.Common.Validation;
using App.Common.Helpers;
using App.Entity.ProductManagement;
using App.Context;
using App.Service.Common;
using App.Repository.Store;
using App.Repository.Common;
using App.Service.Common.File;

namespace App.Service.Impl.ProductManagement
{
    public class ProductService : IProductService
    {
        public void Delete(Guid id)
        {
            ValidateDeleteRequest(id);
            using (IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IProductRepository repository = IoC.Container.Resolve<IProductRepository>(uow);
                repository.Delete(id.ToString());
                uow.Commit();
            }
        }

        private void ValidateDeleteRequest(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new ValidationException("productManagement.products.validation.idIsInvalid");
            }
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            if (repository.GetById(id.ToString()) == null)
            {
                throw new ValidationException("productManagement.products.validation.itemNotExist");
            }
        }

        public IList<ProductListItem> GetProducts()
        {
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            return repository.GetItems<ProductListItem>();
        }

        public GetProductResponse Get(Guid id)
        {
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            Product product = repository.GetById(id.ToString());
            GetProductResponse response = ObjectHelper.Convert<GetProductResponse>(product);
            if (product != null)
            {
                IFileRepository fileRepo = IoC.Container.Resolve<IFileRepository>();
                response.Photos = fileRepo.GetByIds<FileUploadPreview>(GuidHelper.ToGuid(product.Attachments));
            }
            return response;
        }

        public CreateProductResponse Create(CreateProductRequest request)
        {
            ValidateCreateRequest(request);
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IProductRepository repository = IoC.Container.Resolve<IProductRepository>(uow);
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                IStoreRepository storeRepo = IoC.Container.Resolve<IStoreRepository>(uow);
                App.Entity.ProductManagement.Product item = GetProductFromRequest(request);
                item.Store = storeRepo.GetById(request.StoreId.ToString());
                repository.Add(item);
                uow.Commit();
                return ObjectHelper.Convert<CreateProductResponse>(item);
            }

        }

        private Product GetProductFromRequest(CreateProductRequest request)
        {
            App.Entity.ProductManagement.Product product = new Product();
            product.Id = request.Id;
            product.Name = request.Name;
            product.Key = UtilHelper.ToKey(request.Name);
            product.Price = product.Price;
            product.FromDate = request.FromDate;
            product.ToDate = request.ToDate;
            product.Description = request.Description;
            return product;
        }

        private void ValidateCreateRequest(CreateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("productManagement.addOrUpdateProduct.validation.nameIsRequired");
            }
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            if (repository.GetByName(request.Name) != null)
            {
                throw new ValidationException("productManagement.addOrUpdateProduct.validation.nameAlreadyExisted");
            }
        }

        public void Update(UpdateProductRequest request)
        {
            ValidateUpdateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IProductRepository repository = IoC.Container.Resolve<IProductRepository>(uow);
                Product item = repository.GetById(request.Id.ToString());
                item.Name = request.Name;
                item.Key = App.Common.Helpers.UtilHelper.ToKey(request.Name);
                item.Status = request.Status;
                item.Price = request.Price;
                item.FromDate = request.FromDate;
                item.ToDate = request.ToDate;
                item.Description = request.Description;
                item.Attachments = string.Empty;
                IList<Guid> ids = new List<Guid>();
                foreach (FileUploadResponse fileItem in request.Photos)
                {
                    if (fileItem == null || fileItem.Id == null) { continue; }
                    ids.Add(fileItem.Id);
                }
                item.Attachments = GuidHelper.ToString(ids);
                repository.Update(item);
                uow.Commit();
            }
        }
        private void ValidateUpdateRequest(UpdateProductRequest request)
        {
            if (request.Id == null || request.Id == Guid.Empty)
            {
                throw new ValidationException("productManagemnet.addOrUpdateProduct.validation.idIsInvalid");
            }
            IProductRepository repository = IoC.Container.Resolve<IProductRepository>();
            Product item = repository.GetById(request.Id.ToString());
            if (item == null)
            {
                throw new ValidationException("productManagemnet.addOrUpdateProduct.validation.itemNotExist");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("productManagemnet.addOrUpdateProduct.validation.nameIsRequired");
            }
            item = repository.GetByName(request.Name);
            if (item != null && item.Id != request.Id)
            {
                throw new ValidationException("productManagemnet.addOrUpdateProduct.validation.nameAlreadyExisted");
            }
        }
    }
}
