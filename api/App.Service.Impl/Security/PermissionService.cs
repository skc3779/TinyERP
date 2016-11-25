namespace App.Service.Impl.Security
{
    using System.Collections.Generic;
    using App.Service.Security;
    using App.Repository.Secutiry;
    using App.Common.DI;
    using App.Entity.Security;
    using App.Common;
    using App.Common.Data;
    using System;
    using Context;
    using App.Common.Validation;
    using Service.Security.Permission;
    using App.Common.Helpers;

    internal class PermissionService : IPermissionService
    {
        public void CreateIfNotExist(IList<Permission> pers)
        {
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IPermissionRepository perRepository = IoC.Container.Resolve<IPermissionRepository>(uow);
                foreach (Permission per in pers)
                {
                    if (perRepository.GetByKey(per.Key) != null) { continue; }
                    perRepository.Add(per);
                }

                uow.Commit();
            }
        }

        public Permission Create(CreatePermissionRequest permission)
        {
            this.ValidateCreatePermissionRequest(permission);
            using (App.Common.Data.IUnitOfWork uow = new App.Common.Data.UnitOfWork(new App.Context.AppDbContext(IOMode.Write)))
            {
                IPermissionRepository perRepository = IoC.Container.Resolve<IPermissionRepository>(uow);
                Permission per = new Permission(permission.Name, permission.Key, permission.Description);
                perRepository.Add(per);
                uow.Commit();
                return per;
            }
        }

        private void ValidateCreatePermissionRequest(CreatePermissionRequest permission)
        {
            IValidationException validationException = ValidationHelper.Validate(permission);

            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>();
            if (perRepo.GetByName(permission.Name) != null)
            {
                validationException.Add(new App.Common.Validation.ValidationError("security.addPermission.validation.nameAlreadyExist"));
            }

            if (perRepo.GetByKey(permission.Key) != null)
            {
                validationException.Add(new App.Common.Validation.ValidationError("security.addPermission.validation.keyAlreadyExist"));
            }

            validationException.ThrowIfError();
        }

        public IList<PermissionAsKeyNamePair> GetPermissions()
        {
            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>();
            return perRepo.GetPermissions<PermissionAsKeyNamePair>();
        }

        public void Delete(Guid id)
        {
            this.ValidateDeleteRequest(id);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>(uow);
                perRepo.Delete(id.ToString());
                uow.Commit();
            }
        }

        private void ValidateDeleteRequest(Guid id)
        {
            if (id == null)
            {
                throw new ValidationException("security.permissons.permissionIdIsInvalid");
            }

            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>();
            if (perRepo.GetById(id.ToString()) == null)
            {
                throw new ValidationException("security.permissons.permissionIdIsInvalid");
            }
        }

        public GetPermissionResponse GetPermission(Guid id)
        {
            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>();
            return perRepo.GetById<GetPermissionResponse>(id.ToString());
        }

        public void Update(UpdatePermissionRequest request)
        {
            this.ValidateUpdateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>(uow);
                Permission existedPermission = perRepo.GetById(request.Id.ToString());
                existedPermission.Name = request.Name;
                existedPermission.Key = request.Key;
                existedPermission.Description = request.Description;
                perRepo.Update(existedPermission);
                uow.Commit();
            }
        }

        private void ValidateUpdateRequest(UpdatePermissionRequest request)
        {
            IValidationException validationException = new ValidationException();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                validationException.Add(new App.Common.Validation.ValidationError("security.addPermission.validation.nameIsRequire"));
            }

            IPermissionRepository perRepo = IoC.Container.Resolve<IPermissionRepository>();
            Permission per = perRepo.GetByName(request.Name);
            if (per != null && per.Id != request.Id)
            {
                validationException.Add(new App.Common.Validation.ValidationError("security.addPermission.validation.nameAlreadyExist"));
            }

            if (string.IsNullOrWhiteSpace(request.Key))
            {
                validationException.Add(new App.Common.Validation.ValidationError("security.addPermission.validation.keyIsRequire"));
            }

            per = perRepo.GetByName(request.Key);
            if (per != null && per.Id != request.Id)
            {
                validationException.Add(new App.Common.Validation.ValidationError("security.addPermission.validation.keyAlreadyExist"));
            }

            validationException.ThrowIfError();
        }
    }
}
