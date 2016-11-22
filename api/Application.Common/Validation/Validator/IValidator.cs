using System.Collections.Generic;

namespace App.Common.Validation.Validator
{
    public interface IValidator
    {
        bool CheckRequire(object value);
        bool CheckValueInRange(object value, object lowerBound, object upperBound);
        bool Match(object value, object evaluator);
        bool CheckValueInCollection(object value, IEnumerable<object> values);
    }
}