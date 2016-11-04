using System;
using System.Collections.Generic;
using App.Service.ProductManagement.Category;
using App.Common.Helpers;
using App.Common.Validation;
using App.Common.DI;
using App.Common;
using App.Repository.ProductManagement;
using App.Common.Data;
using App.Entity.ProductManagement;
using App.Service.Security;
using App.Context;

namespace App.Service.Impl.ProductManagement
{
    class CategoryService : ICategoryService
    {
        public IList<CategoryListItem> GetCategories()
        {
            ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>();
            return repository.GetItems<CategoryListItem>();
        }

        public GetCategoryResponse Get(Guid id)
        {
            ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>();
            return repository.GetById<GetCategoryResponse>(id.ToString());
        }

        public CreateCategoryResponse Create(CreateCategoryRequest request)
        {
            ValidateCreateRequest(request);
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>(uow);
                ProductCategory item = new ProductCategory(request.Name, request.Status, request.Description, request.ParentId);
                repository.Add(item);
                uow.Commit();
                return ObjectHelper.Convert<CreateCategoryResponse>(item);
            }

        }
        private void ValidateCreateRequest(CreateCategoryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("productManagement.addOrUpdateCategory.validation.nameIsRequired");
            }
            ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>();
            if (repository.GetByName(request.Name) != null)
            {
                throw new ValidationException("productManagement.addOrUpdateCategory.validation.nameAlreadyExisted");
            }
        }



        public DeleteCategoryResponse Delete(Guid id)
        {
            ValidateDeleteRequest(id);
            using (IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>(uow);
                DeleteCategoryResponse deleteResponse = repository.GetById<DeleteCategoryResponse>(id.ToString());
                repository.Delete(id.ToString());
                uow.Commit();
                return deleteResponse;
            }
        }
        private void ValidateDeleteRequest(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new ValidationException("productManagement.categories.validation.idIsInvalid");
            }
            ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>();
            if (repository.GetById(id.ToString()) == null)
            {
                throw new ValidationException("productManagement.categories.validation.itemNotExist");
            }
        }



        public void Update(UpdateCategoryRequest request)
        {
            ValidateUpdateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>(uow);
                ProductCategory item = repository.GetById(request.Id.ToString());
                item.Name = request.Name;
                item.Key = App.Common.Helpers.UtilHelper.ToKey(request.Name);
                item.Status = request.Status;
                item.Description = request.Description;
                item.ParentId = request.ParentId;
                uow.Commit();
            }
        }
        private void ValidateUpdateRequest(UpdateCategoryRequest request)
        {
            if (request.Id == null || request.Id == Guid.Empty)
            {
                throw new ValidationException("productManagemnet.addOrUpdateCategory.validation.idIsInvalid");
            }
            ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>();
            ProductCategory item = repository.GetById(request.Id.ToString());
            if (item == null)
            {
                throw new ValidationException("productManagemnet.addOrUpdateCategory.validation.itemNotExist");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("productManagemnet.addOrUpdateCategory.validation.nameIsRequired");
            }
            item = repository.GetByName(request.Name);
            if (item != null && item.Id != request.Id)
            {
                throw new ValidationException("productManagemnet.addOrUpdateCategory.validation.nameAlreadyExisted");
            }
        }

        public ProductCategory GetByName(string categoryName)
        {
            ICategoryRepository repository = IoC.Container.Resolve<ICategoryRepository>();
            return repository.GetByName(categoryName);
        }
    }
}
