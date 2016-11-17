namespace App.Repository.Impl.Support
{
    using App.Common.Data;
    using App.Common.Data.MSSQL;
    using App.Context;
    using App.Repository.Support;

    internal class RequestRepository : BaseRepository<App.Entity.Support.Request>, IRequestRepository
    {
        public RequestRepository() : base(new AppDbContext())
        {
        }

        public RequestRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {
        }
    }
}
