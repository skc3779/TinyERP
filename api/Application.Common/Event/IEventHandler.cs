using App.Common.Tasks;

namespace App.Common.Event
{
    public interface IEventHandler<TEventType>: IBaseTask<TEventType> where TEventType : IEvent
    {
        //void Execute(TEventType ev);
    }
}