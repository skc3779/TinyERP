namespace App.Common.Connector
{
    using App.Common.Http;

    public interface IConnector
    {
        IResponseData<TEntity> Delete<TEntity>(string uri);
        IResponseData<TEntity> Create<TEntity>(string uri, TEntity data);
        IResponseData<TEntity> Update<TEntity>(string uri, TEntity data);
        IResponseData<TEntity> Get<TEntity>(string uri);
    }
}
