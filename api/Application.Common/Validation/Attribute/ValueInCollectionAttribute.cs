namespace App.Common.Validation.Attribute
{
    using App.Common.Validation.Validator;
    using System.Collections.Generic;

    public class ValueInCollectionAttribute : BaseAttribute
    {
        public IEnumerable<object> Values { get; set; }
        public ValueInCollectionAttribute(string key, IEnumerable<object> values) : base(key)
        {
            this.Values = values;
        }

        public override bool IsValid(ValidationRequest validateRequest)
        {
            IValidator validator = ValidatorResolver.Resolve(validateRequest.DataType);
            return validator.CheckValueInCollection(validateRequest.Value, this.Values);
        }
    }
}
