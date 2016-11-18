namespace App.Common.Tasks
{
    using System.Web;

    public interface IApplicationEndedTask : IBaseTask<HttpContext>
    {
    }
}