using System;
using System.Collections.Generic;
using App.Service.Inventory;
using App.Common.Data;
using App.Common.Validation;
using App.Repository.Inventory;
using App.Common.DI;
using App.Entity.ProductManagement;
using App.Common;

namespace App.Service.Impl.Inventory
{
    public class CategoryService : ICategoryService
    {
        public void CreateIfNotExist(IList<ProductCategory> categories)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>(uow);
                foreach (ProductCategory category in categories)
                {
                    if (categoryRepository.GetById(category.Id.ToString()) != null) { continue; }
                    categoryRepository.Add(category);
                }
                uow.Commit();
            }
        }

        public IList<CategoryListItem> GetCategories()
        {
            ICategoryRepository categoryRepository = IoC.Container.Resolve<ICategoryRepository>();
            return categoryRepository.GetCategories<CategoryListItem>();
        }
    }
}
