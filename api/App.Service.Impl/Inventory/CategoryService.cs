using App.Common.DI;
using App.Repository.Inventory;
using App.Service.Inventory;
using App.Entity.Inventory;
using App.Common.Validation;
using App.Service.Inventory.Config;
using App.Common.Data;
using App.Context;
using App.Common;
using System;

namespace App.Service.Impl.Inventory
{
    public class CategoryService : ICategoryService
    {
        public GetCategoryResponse GetById(string itemId)
        {
            ICategoryRepository catRepo = IoC.Container.Resolve<ICategoryRepository>();
            return catRepo.GetById<GetCategoryResponse>(itemId);
        }

        public void Create(CreateCategoryRequest request)
        {
            ValiateForCreation(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository catRepo = IoC.Container.Resolve<ICategoryRepository>(uow);
                Category category = new Category(request.Name, request.Description);
                catRepo.Add(category);
                uow.Commit();
            }
        }

        private void ValiateForCreation(CreateCategoryRequest request)
        {
            ICategoryRepository catRepo = IoC.Container.Resolve<ICategoryRepository>();
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameIsRequired");
            }
            if (request.Name.Length > ValidationConfig.nameLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
            if (catRepo.GetByName(request.Name) != null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
            }
            if (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Length > ValidationConfig.descriptionLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
        }

        public void Update(string itemId, UpdateCategoryRequest request)
        {
            ValiateForUpdate(itemId, request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository catRepo = IoC.Container.Resolve<ICategoryRepository>();
                Category category = catRepo.GetById(itemId);
                category.Name = request.Name;
                category.Description = request.Description;
                catRepo.Update(category);
                uow.Commit();
            }
        }

        private void ValiateForUpdate(string itemId, UpdateCategoryRequest request)
        {
            ICategoryRepository catRepo = IoC.Container.Resolve<ICategoryRepository>();
            Category oldItem = catRepo.GetById(itemId);
            if (oldItem == null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.itemIsNotExist");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameIsRequired");
            }
            if (request.Name.Length > ValidationConfig.nameLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
            if (oldItem.Name != request.Name)
            {
                if (catRepo.GetByName(request.Name) != null)
                {
                    throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
                }
            }
            if (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Length > ValidationConfig.descriptionLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
        }
    }
}
