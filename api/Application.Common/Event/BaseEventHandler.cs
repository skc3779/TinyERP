using App.Common.Tasks;
using System;

namespace App.Common.Event
{
    public class BaseEventHandler<TEntity> :BaseTask<TEntity>, IEventHandler<TEntity> where TEntity: IEvent
    {
        public BaseEventHandler():base(ApplicationType.All){}
        public override bool IsValid(ApplicationType type)
        {
            return true;
        }
    }
}
