namespace App.Common.Connector
{
    public class ConnectorFactory
    {
        public IConnector Create(ConnectorType type){
            switch (type)
            {
                case ConnectorType.REST:
                default:
                    return new RESTConnector();
            }
        }
    }
}
