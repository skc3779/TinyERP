namespace App.Common.Event
{
    public class BaseEventManager : IEventManager
    {
        public void pubish<TEventType>(TEventType eventType) where TEventType : IEvent
        {
            App.Common.Helpers.AssemblyHelper.ExecuteTasks<IEventHandler<TEventType>, TEventType>(eventType);
        }
    }
}