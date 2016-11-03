namespace App.Common.Event
{
    public interface IEventHandler<TEventType> where TEventType : IEvent
    {
        void Execute(TEventType ev);
    }
}