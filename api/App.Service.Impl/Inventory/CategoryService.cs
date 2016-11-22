namespace App.Service.Impl.Inventory
{
    using System.Collections.Generic;
    using App.Service.Inventory;
    using App.Common.Validation;
    using App.Repository.Inventory;
    using App.Common.DI;
    using App.Common;
    using App.Entity.Inventory;
    using App.Common.Data;
    using Context;
    using Service.Inventory.Config;

    public class CategoryService : ICategoryService
    {
        public void CreateIfNotExist(List<CreateCategoryRequest> createCategoryRequests)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                foreach (CreateCategoryRequest request in createCategoryRequests)
                {
                    try
                    {
                        this.ValiateCreateCategoryRequest(request);
                        Category category = new Category(request.Name, request.Description);
                        categoryRepository.Add(category);
                    }
                    catch (ValidationException exception)
                    {
                        if (exception.HasExceptionKey("inventory.addOrUpdateCategory.validation.nameAlreadyExisted"))
                        {
                            continue;
                        }
                    }
                }

                uow.Commit();
            }
        }

        public IList<CategoryListItem> GetCategories()
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            return categoryRepository.GetItems<CategoryListItem>();
        }

        public GetCategoryResponse GetById(string id)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            return categoryRepository.GetById<GetCategoryResponse>(id);
        }

        public void Create(CreateCategoryRequest createCategoryRequest)
        {
            this.ValiateCreateCategoryRequest(createCategoryRequest);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                Category category = new Category(createCategoryRequest.Name, createCategoryRequest.Description);
                categoryRepository.Add(category);
                uow.Commit();
            }
        }

        private void ValiateCreateCategoryRequest(CreateCategoryRequest createCategoryRequest)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            if (string.IsNullOrWhiteSpace(createCategoryRequest.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameRequired");
            }

            if (createCategoryRequest.Name.Length > ValidationConfig.MaxNameLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }

            if (categoryRepository.GetByName(createCategoryRequest.Name) != null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
            }

            if (!string.IsNullOrWhiteSpace(createCategoryRequest.Description) && createCategoryRequest.Description.Length > ValidationConfig.MaxDescriptionLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
        }

        public void Update(UpdateCategoryRequest updateCategoryRequest)
        {
            this.ValiateUpdateCategoryRequest(updateCategoryRequest);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                Category category = categoryRepository.GetById(updateCategoryRequest.Id);
                category.Name = updateCategoryRequest.Name;
                category.Description = updateCategoryRequest.Description;
                categoryRepository.Update(category);
                uow.Commit();
            }
        }

        private void ValiateUpdateCategoryRequest(UpdateCategoryRequest updateCategoryRequest)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            Category oldCategory = categoryRepository.GetById(updateCategoryRequest.Id);
            if (oldCategory == null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.categoryNotExisted");
            }

            if (string.IsNullOrWhiteSpace(updateCategoryRequest.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameRequired");
            }

            if (updateCategoryRequest.Name.Length > ValidationConfig.MaxNameLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }

            if (oldCategory.Name != updateCategoryRequest.Name)
            {
                if (categoryRepository.GetByName(updateCategoryRequest.Name) != null)
                {
                    throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
                }
            }

            if (!string.IsNullOrWhiteSpace(updateCategoryRequest.Description) && updateCategoryRequest.Description.Length > ValidationConfig.MaxDescriptionLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
        }
    }
}
