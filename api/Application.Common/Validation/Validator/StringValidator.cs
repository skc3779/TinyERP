namespace App.Common.Validation.Validator
{
    public class StringValidator : BaseValidator
    {
        public override bool Require(object value)
        {
            return value != null && (value is string) && !string.IsNullOrWhiteSpace((string)value);
        }
    }
}
