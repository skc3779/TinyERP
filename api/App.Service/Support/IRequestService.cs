using System;
using System.Collections.Generic;

namespace App.Service.Support
{
    public interface IRequestService
    {
        void CreateRequest(CreateRequest request);
        IList<SupportRequestListItem> GetRequests();
        GetRequestResponse GetRequest(Guid itemId);
    }
}
