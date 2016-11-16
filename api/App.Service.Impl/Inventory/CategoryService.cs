using System.Collections.Generic;
using App.Service.Inventory;
using App.Common.Validation;
using App.Repository.Inventory;
using App.Common.DI;
using App.Common;
using App.Entity.Inventory;

namespace App.Service.Impl.Inventory
{
    public class CategoryService : ICategoryService
    {
        public void CreateIfNotExist(List<Category> categories)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                foreach (Category category in categories)
                {
                    ValidateCreateCategoryRequest(category);
                    if (categoryRepository.GetById(category.Id.ToString()) != null)
                    {
                        continue;
                    }
                    categoryRepository.Add(category);
                }
                uow.Commit();
            }
        }

        private void ValidateCreateCategoryRequest(Category category)
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new ValidationException("categories.addProductCategory.invalidName");
            }

            if (categoryRepository.GetByName(category.Name) != null)
            {
                throw new ValidationException("categories.addProductCategory.nameIsReadyExist");
            }
        }

        public IList<CategoryListItem> GetCategories()
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            return categoryRepository.GetItems<CategoryListItem>();
        }
    }
}
