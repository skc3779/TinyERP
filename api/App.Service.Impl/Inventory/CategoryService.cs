namespace App.Service.Impl.Inventory
{
    using System.Collections.Generic;
    using App.Service.Inventory;
    using App.Common.Validation;
    using App.Repository.Inventory;
    using App.Common.DI;
    using App.Common;
    using App.Entity.Inventory;

    public class CategoryService : ICategoryService
    {
        public void CreateIfNotExist(List<CreateCategoryRequest> createCategoriesRequest)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                foreach (CreateCategoryRequest createCategoryRequest in createCategoriesRequest)
                {
                    try
                    {
                        this.ValidateCreateCategoryRequest(createCategoryRequest);
                        Category category = new Category(createCategoryRequest.Name, createCategoryRequest.Description);
                        categoryRepository.Add(category);
                    }
                    catch (ValidationException exception)
                    {
                        if (exception.HasExceptionKey("inventory.addCategory.validation.nameAlreadyExist"))
                        {
                            continue;
                        }
                    }
                }

                uow.Commit();
            }
        }

        private void ValidateCreateCategoryRequest(CreateCategoryRequest createCategoryRequest)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            if (string.IsNullOrEmpty(createCategoryRequest.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameRequired");
            }

            if (categoryRepository.GetByName(createCategoryRequest.Name) != null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
            }
        }

        public IList<CategoryListItem> GetCategories()
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            return categoryRepository.GetItems<CategoryListItem>();
        }

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
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameRequired");
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
                ICategoryRepository catRepo = IoC.Container.Resolve<ICategoryRepository>(uow);
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
                throw new ValidationException("inventory.addOrUpdateCategory.validation.categoryIsNotExist");
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
