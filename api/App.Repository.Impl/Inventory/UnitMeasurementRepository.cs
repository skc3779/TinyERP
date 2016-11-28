namespace App.Repository.Impl.Inventory
{
    using App.Common.Data.MSSQL;
    using App.Context;
    using Repository.Inventory;
    using App.Common.Data;
    using Entity.Inventory;

    public class UnitMeasurementRepository : BaseContentRepository<UnitMeasurement>, IUnitMeasurementRepository
    {
        public UnitMeasurementRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {
        }

        public UnitMeasurementRepository() : base(new AppDbContext(App.Common.IOMode.Read))
        {
        }
    }
}