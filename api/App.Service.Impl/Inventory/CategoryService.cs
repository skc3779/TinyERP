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
        public void CreateIfNotExist(List<CreateCategoryRequest> createCategoryRequest)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                foreach (CreateCategoryRequest request in createCategoryRequest)
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

        public void Create(CreateCategoryRequest request)
        {
            this.ValiateCreateCategoryRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                Category category = new Category(request.Name, request.Description);
                categoryRepository.Add(category);
                uow.Commit();
            }
        }

        private void ValiateCreateCategoryRequest(CreateCategoryRequest request)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameRequired");
            }

            if (request.Name.Length > ValidationConfig.MaxNameLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }

            if (categoryRepository.GetByName(request.Name) != null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
            }

            if (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Length > ValidationConfig.MaxDescriptionLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
        }

        public void Update(string id, UpdateCategoryRequest request)
        {
            this.ValiateUpdateCategoryRequest(id, request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                Category category = categoryRepository.GetById(id);
                category.Name = request.Name;
                category.Description = request.Description;
                categoryRepository.Update(category);
                uow.Commit();
            }
        }

        private void ValiateUpdateCategoryRequest(string id, UpdateCategoryRequest request)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            Category oldItem = categoryRepository.GetById(id);
            if (oldItem == null)
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.categoryNotExisted");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("inventory.addOrUpdateCategory.validation.nameRequired");
            }

            if (request.Name.Length > ValidationConfig.MaxNameLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }

            if (oldItem.Name != request.Name)
            {
                if (categoryRepository.GetByName(request.Name) != null)
                {
                    throw new ValidationException("inventory.addOrUpdateCategory.validation.nameAlreadyExisted");
                }
            }

            if (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Length > ValidationConfig.MaxDescriptionLength)
            {
                throw new ValidationException("common.form.validation.fieldTooLong");
            }
        }
    }
}
