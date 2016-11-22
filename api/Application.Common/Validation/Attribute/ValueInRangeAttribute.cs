namespace App.Common.Validation.Attribute
{
    using App.Common.Validation.Validator;

    public class ValueInRangeAttribute : BaseAttribute
    {
        public object LowerBound { get; set; }
        public object UpperBound { get; set; }
        public ValueInRangeAttribute(string key, object lowerBound, object upperBound) : base(key)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public override bool IsValid(ValidationRequest validateRequest)
        {
            IValidator validator = ValidatorResolver.Resolve(validateRequest.DataType);
            return validator.CheckValueInRange(validateRequest.Value, this.LowerBound, this.UpperBound);
        }
    }
}
