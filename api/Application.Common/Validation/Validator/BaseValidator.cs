using System;
using App.Common.Validation.Attribute;

namespace App.Common.Validation.Validator
{
    public abstract class BaseValidator : IValidator
    {
        public virtual bool Require(object value)
        {
            throw new NotImplementedException();
        }
    }
}