namespace App.Entity.Inventory
{
    using App.Common.Data;
    public class UnitMeasurement : BaseContent
    {
        public UnitMeasurement() : base()
        {
        }

        public UnitMeasurement(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}