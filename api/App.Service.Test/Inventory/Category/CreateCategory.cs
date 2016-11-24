using App.Common;
using App.Common.DI;
using App.Common.UnitTest;
using App.Common.Validation;
using App.Service.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace App.Service.Test.Inventory.Category
{
    [TestClass]
    public class CreateCategory : BaseUnitTest
    {
        [TestInitialize()]
        public void Init()
        {
            this.Application.OnApplicationStarted();
        }

        [TestCleanup()]
        public void Finished()
        {
            this.Application.OnApplicationEnded();
        }

        [TestMethod]
        public void CreateCategory_ShouldBeSuccess_WithValidRequest()
        {
            string name = "Name of Category" + Guid.NewGuid().ToString("N");
            string desc = "Desc of Category";
            ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
            App.Entity.Inventory.Category item = this.CreateCategoryItem(name, desc);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void CreateCategory_ShouldGetException_WithEmptyName()
        {
            try
            {
                string name = string.Empty;
                string desc = "Desc of Category";
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                this.CreateCategoryItem(name, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("inventory.addOrUpdateCategory.validation.nameIsRequired"));
            }
        }

        [TestMethod]
        public void CreateCategory_ShouldGetException_WithDuplicatedName()
        {
            try
            {
                string name = "Duplicated Name" + Guid.NewGuid().ToString("N");
                string desc = "Desc of Category";
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                this.CreateCategoryItem(name, desc);
                this.CreateCategoryItem(name, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("inventory.addOrUpdateCategory.validation.nameAlreadyExisted"));
            }
        }

        [TestMethod]
        public void CreateCategory_ShouldGetException_WithNameTooLong()
        {
            try
            {
                string name = "Name Too Long" + new String('g', FormValidationRules.MaxNameLength);
                string desc = "Desc of Category";
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                this.CreateCategoryItem(name, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("common.form.validation.fieldTooLong"));
            }
        }

        [TestMethod]
        public void CreateCategory_ShouldGetException_WithDescriptionTooLong()
        {
            try
            {
                string name = "Name of Category";
                string desc = "Desc Too Long" + new String('g', FormValidationRules.MaxDescriptionLength);
                ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
                this.CreateCategoryItem(name, desc);
                Assert.IsTrue(false);
            }
            catch (ValidationException ex)
            {
                Assert.IsTrue(ex.HasExceptionKey("common.form.validation.fieldTooLong"));
            }
        }

        private App.Entity.Inventory.Category CreateCategoryItem(string name, string desc)
        {
            CreateCategoryRequest request = new CreateCategoryRequest(name, desc);
            ICategoryService catService = IoC.Container.Resolve<ICategoryService>();
            App.Entity.Inventory.Category item = catService.Create(request);
            return item;
        }
    }
}
