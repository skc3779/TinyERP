using App.Common.Event;

namespace App.EventHandler.Support
{
    public interface ISupportRequestEventHandler: IEventHandler<SupportRequestOnStatusChanged>
    {
    }
}
