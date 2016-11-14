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
    public class ProductCategoryService : IProductCategoryService
    {
        public void CreateIfNotExist(IList<ProductCategory> productCategories)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IProductCategoryRepository productCategoryRepository = IoC.Container.Resolve<IProductCategoryRepository>(uow);
                foreach (ProductCategory productCategory in productCategories)
                {
                    ValidationProducCategory(productCategory);
                    if (productCategoryRepository.GetById(productCategory.Id.ToString()) != null || productCategoryRepository.GetByName(productCategory.Name) != null)
                    {
                        continue;
                    }
                    productCategoryRepository.Add(productCategory);
                }
                uow.Commit();
            }
        }

        private void ValidationProducCategory(ProductCategory productCategory)
        {
            if (string.IsNullOrEmpty(productCategory.Name))
            {
                throw new ValidationException("categories.addProductCategory.invalidName");
            };
        }

        public IList<CategoryListItem> GetProductCategories()
        {
            IProductCategoryRepository productCategoryRepository = IoC.Container.Resolve<IProductCategoryRepository>();
            return productCategoryRepository.GetProductCategories<CategoryListItem>();
        }
    }
}
