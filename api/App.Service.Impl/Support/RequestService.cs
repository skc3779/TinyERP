using System;
using App.Service.Support;
using App.Common.Data;
using App.Context;
using App.Common;
using App.Common.DI;
using App.Common.Validation;
using App.Repository.Support;
using App.Entity.Support;
using System.Collections.Generic;

namespace App.Service.Impl.Support
{
    internal class RequestService : IRequestService
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

        public GetRequestResponse GetRequest(Guid itemId)
        {
            IRequestRepository repo = IoC.Container.Resolve<IRequestRepository>();
            return repo.GetById<GetRequestResponse>(itemId.ToString());
        }

        public IList<SupportRequestListItem> GetRequests()
        {
            IRequestRepository repo = IoC.Container.Resolve<IRequestRepository>();
            return repo.GetItems<SupportRequestListItem>();
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
