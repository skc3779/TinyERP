using App.Common.DI;
using App.Common.Event;
using App.Common.Tasks;
using App.EventHandler.Support;

namespace App.EventHandler.Impl
{
    public class Bootstrap :BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap() : base(App.Common.ApplicationType.All) { }
        public override void Execute(IBaseContainer context)
        {
            context.RegisterTransient<IEventHandler<SupportRequestOnStatusChanged>, App.EventHandler.Impl.Support.SupportRequestEventHandler>();
        }
    }
}
