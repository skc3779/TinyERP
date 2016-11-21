using App.Common.Validation.Validator;

namespace App.Common.Validation.Attribute
{
    public class RequiredAttribute : BaseAttribute
    {
        public RequiredAttribute(string key) : base(key)
        {
        }
        public override bool IsValid(ValidationRequest validateRequest)
        {
            IValidator validator = ValidatorResolver.Resolve(validateRequest.DataType);
            return validator.Require(validateRequest.Value);
        }
    }
}