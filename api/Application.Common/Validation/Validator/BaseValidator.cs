namespace App.Common.Validation.Validator
{
    using System;

    public abstract class BaseValidator : IValidator
    {
        public virtual bool Require(object value)
        {
            throw new NotImplementedException();
        }

        public virtual bool ValueInRange(object value, object lowerBound, object upperBound)
        {
            throw new NotImplementedException();
        }
    }
}