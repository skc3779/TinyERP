using App.Common.DI;
using App.Common.Logging;
using System;
using System.Collections.Generic;

namespace App.Common.Event
{
    public class BaseEventManager : IEventManager
    {
        public void pubish<TEventType>(TEventType eventType) where TEventType : IEvent
        {
            IList<IEventHandler<TEventType>> handlers = IoC.Container.ResolveAll<IEventHandler<TEventType>>();
            if (handlers == null || handlers.Count == 0) { return; }
            foreach (IEventHandler<TEventType> handler in handlers)
            {
                try
                {
                    handler.Execute(eventType);
                }
                catch (Exception ex)
                {
                    ILogger logger = IoC.Container.Resolve<ILogger>();
                    logger.Error("Error while handle event:"+ typeof(TEventType).FullName);
                    logger.Error(ex);
                }

            }
        }
    }
}
