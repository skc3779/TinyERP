namespace App.Api.Features.Security
{
    using App.Common.Data;
    using App.Common.DI;
    using App.Common.Http;
    using App.Common.Validation;
    using App.Service.Security;
    using App.Service.Security.Permission;
    using Entity.Security;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/permissions")]
    public class PermissionsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IResponseData<IList<PermissionAsKeyNamePair>> GetPermissions()
        {
            IResponseData<IList<PermissionAsKeyNamePair>> response = new ResponseData<IList<PermissionAsKeyNamePair>>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                IList<PermissionAsKeyNamePair> pers = permissionService.GetPermissions();
                response.SetData(pers);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public IResponseData<GetPermissionResponse> GetPermission([FromUri]Guid id)
        {
            IResponseData<GetPermissionResponse> response = new ResponseData<GetPermissionResponse>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                GetPermissionResponse per = permissionService.GetPermission(id);
                response.SetData(per);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return response;
        }

        [HttpPost]
        [Route("")]
        public IResponseData<Permission> CreatePermission(CreatePermissionRequest permission)
        {
            IResponseData<Permission> response = new ResponseData<Permission>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                Permission per = permissionService.Create(permission);
                response.SetData(per);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public IResponseData<string> UpdatePermission([FromUri]Guid id, UpdatePermissionRequest request)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                request.Id = id;
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                permissionService.Update(request);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public IResponseData<string> DeletePermission([FromUri]Guid id)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                permissionService.Delete(id);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }

            return response;
        }
    }
}
