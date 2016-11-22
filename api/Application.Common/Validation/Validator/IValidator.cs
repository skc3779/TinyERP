namespace App.Common.Validation.Validator
{
    public interface IValidator
    {
        bool Require(object value);
        bool ValueInRange(object value, object lowerBound, object upperBound);
        bool Match(object value, object evaluator);
    }
}