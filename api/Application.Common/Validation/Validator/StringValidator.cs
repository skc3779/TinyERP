namespace App.Common.Validation.Validator
{
    public class StringValidator : BaseValidator
    {
        public override bool Require(object value)
        {
            return value != null && (value is string) && !string.IsNullOrWhiteSpace((string)value);
        }

        public override bool ValueInRange(object value, object lowerBound, object upperBound)
        {
            string str = value as string;
            int low = (int)lowerBound;
            int upper = (int)upperBound;
            return !string.IsNullOrWhiteSpace(str) && str.Length >= low && str.Length <= upper;
        }
    }
}
