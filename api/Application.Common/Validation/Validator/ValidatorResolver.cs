namespace App.Common.Validation.Validator
{
    public class ValidatorResolver
    {
        public static IValidator Resolve(string type)
        {
            DataType dataType = GetDataType(type);
            switch (dataType)
            {
                case DataType.String:
                default:
                    return new StringValidator();
            }
        }

        private static DataType GetDataType(string type)
        {
            switch (type.ToLower())
            {
                case "system.string":
                default:
                    return DataType.String;
            }
        }
    }
}