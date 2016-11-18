namespace App.Common.UnitTest
{
    public abstract class BaseUnitTest
    {
        public App.Common.IApplication Application { get; protected set; }
        public BaseUnitTest()
        {
            this.Application = App.Common.ApplicationFactory.Create<System.Web.HttpApplication>(App.Common.ApplicationType.UnitTest, null);
        }
    }
}
