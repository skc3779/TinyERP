using System;
using System.Collections.Generic;
using App.Service.Store;
using App.Common.DI;
using App.Repository.Store;
using App.Common.Data;
using App.Context;
using App.Common;
using App.Common.Validation;
using App.Entity.Store;
using App.Common.Logging;
using App.Common.Helpers;
using App.Service.Store.Store;

namespace App.Service.Impl.Store
{
    public class StoreService : IStoreService
    {
        public void Delete(Guid id)
        {
            ValidateDeleteRequest(id);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>(uow);
                App.Entity.Store.Store item = repo.GetById(id.ToString());
                item.Status = StoreItemStatus.Deleted;
                repo.Update(item);
                uow.Commit();
            }
        }

        private void ValidateDeleteRequest(Guid id)
        {
            if (id == null)
            {
                throw new ValidationException("store.stores.validation.idIsInvalid");
            }
            IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>();
            if (repo.GetById(id.ToString()) == null)
            {
                throw new ValidationException("store.stores.validation.itemNotExist");
            }
        }

        public IList<StoreListItem> GetStores()
        {
            IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>();
            return repo.GetStores<StoreListItem>();
        }

        public void CreateIfNotExist(IList<CreateStoreRequest> request)
        {
            ILogger logger = IoC.Container.Resolve<ILogger>();
            foreach (CreateStoreRequest requestItem in request)
            {
                try
                {
                    this.Create(requestItem);
                }
                catch (ValidationException ex)
                {
                    logger.Error(ex);
                }
            }
        }

        private void ValidateCreateRequest(CreateStoreRequest requestItem)
        {
            if (String.IsNullOrWhiteSpace(requestItem.Name))
            {
                throw new ValidationException("store.addOrUpdateStore.validation.nameIsRequired");
            }
            IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>();
            if (repo.GetByName(requestItem.Name) != null)
            {
                throw new ValidationException("store.addOrUpdateStore.validation.nameAlreadyExisted");
            }

            if (requestItem.OwnerId == null)
            {
                throw new ValidationException("store.addOrUpdateStore.validation.ownerIsRequired");
            }

            IAccountRepository accountRepo = IoC.Container.Resolve<IAccountRepository>();
            if (accountRepo.GetById(requestItem.OwnerId.ToString()) == null)
            {
                throw new ValidationException("store.addOrUpdateStore.validation.ownerNotExisted");
            }
        }

        public GetStoreResponse Get(Guid id)
        {
            ValidateGetRequest(id);
            IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>();
            return repo.GetById<GetStoreResponse>(id.ToString());
        }

        private void ValidateGetRequest(Guid id)
        {
            if (id == null)
            {
                throw new ValidationException("store.addOrUpdateStore.idIsInvalid");
            }
        }

        public CreateStoreResponse Create(CreateStoreRequest request)
        {
            ValidateCreateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>(uow);
                IAccountRepository accountRepo = IoC.Container.Resolve<IAccountRepository>(uow);

                App.Entity.Store.Store item = new App.Entity.Store.Store(request.Name, request.Status, request.Description);
                item.Owner = accountRepo.GetById(request.OwnerId.ToString());
                repo.Add(item);

                uow.Commit();
                return ObjectHelper.Convert<CreateStoreResponse>(item);
            }
        }

        public void Update(UpdateStoreRequest request)
        {
            ValidateUpdateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>(uow);
                IAccountRepository accountRepo = IoC.Container.Resolve<IAccountRepository>(uow);
                App.Entity.Store.Store existedItem = repo.GetById(request.Id.ToString());
                existedItem.Name = request.Name;
                existedItem.Owner = accountRepo.GetById(request.Owner.Id.ToString());
                existedItem.Status = request.Status;
                existedItem.Description = request.Description;
                repo.Update(existedItem);
                uow.Commit();
            }
        }

        private void ValidateUpdateRequest(UpdateStoreRequest requestItem)
        {
            if (String.IsNullOrWhiteSpace(requestItem.Name))
            {
                throw new ValidationException("store.addOrUpdateStore.validation.nameIsRequired");
            }
            IStoreRepository repo = IoC.Container.Resolve<IStoreRepository>();
            App.Entity.Store.Store item = repo.GetByName(requestItem.Name);
            if (item != null && item.Id != requestItem.Id)
            {
                throw new ValidationException("store.addOrUpdateStore.validation.nameAlreadyExisted");
            }
            if (requestItem.Owner == null)
            {
                throw new ValidationException("store.addOrUpdateStore.validation.ownerIsRequired");
            }
            IAccountRepository accountRepo = IoC.Container.Resolve<IAccountRepository>();
            if (accountRepo.GetById(requestItem.Owner.Id.ToString()) == null)
            {
                throw new ValidationException("store.addOrUpdateStore.validation.ownerNotExisted");
            }
        }
    }
}
