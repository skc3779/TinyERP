using System;
using App.Common.Http;
using System.Net.Http;

namespace App.Common.Connector
{
    public class RESTConnector : IConnector
    {
        public IResponseData<TEntity> Create<TEntity>(string uri, TEntity data)
        {
            throw new NotImplementedException();
        }

        public IResponseData<TEntity> Delete<TEntity>(string uri)
        {
            throw new NotImplementedException();
        }

        public IResponseData<TEntity> Get<TEntity>(string uri)
        {
            using (HttpClient client = this.CreateHttpClient(baseUrl, options))
            {
                //Send request GET with the requestUrl
                HttpResponseMessage responseMessage = client.GetAsync(requestUrl).Result;

                //Validate status response
                ValidateStatusResponse(responseMessage);

                //Retrieve result from ContentResponse
                TResponse result = ReadContentResponseAsAsync<TResponse>(responseMessage.Content);
                return result;
            }
        }

        public IResponseData<TEntity> Update<TEntity>(string uri, TEntity data)
        {
            throw new NotImplementedException();
        }
    }
}
