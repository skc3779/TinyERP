namespace App.EventHandler.Impl
{
    using App.Common.DI;
    using App.Common.Tasks;

    public class Bootstrap : BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap() : base(App.Common.ApplicationType.All)
        {
        }

        public override void Execute(IBaseContainer context)
        {
        }
    }
}
