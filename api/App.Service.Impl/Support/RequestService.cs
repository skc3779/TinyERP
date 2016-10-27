using System;
using App.Service.Support;
using App.Common.Data;
using App.Context;
using App.Common;
using App.Common.DI;
using App.Common.Validation;
using App.Repository.Support;
using App.Entity.Support;

namespace App.Service.Impl.Support
{
    public class RequestService : IRequestService
    {
        public void CreateRequest(CreateRequest request)
        {
            ValidateCreateRequest(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write))) {
                IRequestRepository repo = IoC.Container.Resolve<IRequestRepository>(uow);
                Request item = new Request(request.Subject, request.Description, request.Email);
                repo.Add(item);
                uow.Commit();
            }
        }

        private void ValidateCreateRequest(CreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Subject)) {
                throw new ValidationException("support.createRequest.validation.subjectIsRequired");
            }
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ValidationException("support.createRequest.validation.emailIsRequired");
            }
        }
    }
}
