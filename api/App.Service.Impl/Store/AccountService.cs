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

namespace App.Service.Impl.Store
{
    public class AccountService : IAccountService
    {
        public void Delete(Guid id)
        {
            ValidateDeleteRequest(id);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>(uow);
                StoreAccount account = repo.GetById(id.ToString());
                account.Status = StoreAccountStatus.Deleted;
                repo.Update(account);
                uow.Commit();
            }
        }

        private void ValidateDeleteRequest(Guid id)
        {
            if (id == null)
            {
                throw new ValidationException("store.accounts.validation.idIsInvalid");
            }
            IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>();
            if (repo.GetById(id.ToString()) == null)
            {
                throw new ValidationException("store.accounts.validation.itemNotExist");
            }
        }

        public IList<AccountListItem> GetAccounts()
        {
            IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>();
            return repo.GetAccounts<AccountListItem>();
        }

        public void CreateIfNotExist(IList<CreateAccountRequest> request)
        {
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                ILogger logger = IoC.Container.Resolve<ILogger>();
                IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>(uow);
                foreach (CreateAccountRequest requestItem in request)
                {
                    try
                    {
                        ValidateCreateRequest(requestItem);
                        StoreAccount account = new StoreAccount(requestItem.Name, requestItem.Email, requestItem.UserName, StoreAccountStatus.InActive, requestItem.Photo, requestItem.Description);
                        repo.Add(account);
                    }
                    catch (ValidationException ex)
                    {
                        logger.Error(ex);
                    }
                }
                uow.Commit();
            }
        }

        private void ValidateCreateRequest(CreateAccountRequest requestItem)
        {
            if (String.IsNullOrWhiteSpace(requestItem.Name))
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.nameIsRequired");
            }
            IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>();
            if (repo.GetByName(requestItem.Name) != null)
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.nameAlreadyExisted");
            }
            if (String.IsNullOrWhiteSpace(requestItem.Email))
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.emailIsRequired");
            }
            if (repo.GetByEmail(requestItem.Email) != null)
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.emailAlreadyExisted");
            }

            if (String.IsNullOrWhiteSpace(requestItem.UserName))
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.userNameIsRequired");
            }
            if (repo.GetByUserName(requestItem.UserName) != null)
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.userNameAlreadyExisted");
            }
        }

        public GetAccountResponse Get(Guid id)
        {
            ValidateGetAccountRequest(id);
            IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>();
            return repo.GetById<GetAccountResponse>(id.ToString());
        }

        private void ValidateGetAccountRequest(Guid id)
        {
            if (id == null)
            {
                throw new ValidationException("store.addOrUpdateAccount.idIsInvalid");
            }
        }

        public CreateAccountResponse Create(CreateAccountRequest request)
        {
            ValidateCreateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>(uow);
                StoreAccount account = new StoreAccount(request.Name, request.Email, request.UserName, request.Status, request.Photo, request.Description);
                repo.Add(account);
                uow.Commit();
                return ObjectHelper.Convert<CreateAccountResponse>(account);
            }
        }

        public void Update(UpdateAccountRequest request)
        {
            ValidateUpdateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>(uow);
                StoreAccount existAccount = repo.GetById(request.Id.ToString());
                existAccount.Name = request.Name;
                existAccount.Email = request.Email;
                existAccount.Status = request.Status;
                existAccount.Description = request.Description;
                repo.Update(existAccount);
                uow.Commit();
            }
        }

        private void ValidateUpdateRequest(UpdateAccountRequest requestItem)
        {
            if (String.IsNullOrWhiteSpace(requestItem.Name))
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.nameIsRequired");
            }
            IAccountRepository repo = IoC.Container.Resolve<IAccountRepository>();
            StoreAccount account = repo.GetByName(requestItem.Name);
            if (account != null && account.Id != requestItem.Id)
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.nameAlreadyExisted");
            }
            if (String.IsNullOrWhiteSpace(requestItem.Email))
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.emailIsRequired");
            }
            account = repo.GetByEmail(requestItem.Email);
            if (account != null && account.Id != requestItem.Id)
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.emailAlreadyExisted");
            }

            if (String.IsNullOrWhiteSpace(requestItem.UserName))
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.userNameIsRequired");
            }
            account = repo.GetByUserName(requestItem.UserName);
            if (account != null && account.Id != requestItem.Id)
            {
                throw new ValidationException("store.addOrUpdateAccount.validation.userNameAlreadyExisted");
            }

        }
    }
}
