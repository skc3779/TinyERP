namespace App.Common.Event
{
    public interface IEventManager
    {
        void pubish<TEventType>(TEventType eventType) where TEventType : IEvent;
    }
}
