namespace App.Common.Validation.Validator
{
    using System.Collections.Generic;
    using App.Common.Helpers;
    using System.Linq;

    public class StringValidator : BaseValidator
    {
        public override bool CheckRequire(object value)
        {
            return value != null && (value is string) && !string.IsNullOrWhiteSpace((string)value);
        }

        public override bool CheckValueInRange(object value, object lowerBound, object upperBound)
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

        public override bool CheckValueInCollection(object value, IEnumerable<object> values)
        {
            string val = value as string;
            IList<string> vals = (values as IEnumerable<string>).ToList();
            return vals.Any(item => item.Equals(val, System.StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
