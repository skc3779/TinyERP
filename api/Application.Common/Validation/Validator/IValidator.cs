using App.Common.Validation.Attribute;

namespace App.Common.Validation.Validator
{
    public interface IValidator
    {
        bool Require(object value);
    }
}