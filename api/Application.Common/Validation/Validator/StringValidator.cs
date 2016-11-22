namespace App.Common.Validation.Validator
{
    using App.Common.Helpers;

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

        public override bool Match(object value, object evaluator)
        {
            string pattern = evaluator as string;
            string val = value as string;
            return RegexHelper.IsMatch(pattern, val);
        }
    }
}
