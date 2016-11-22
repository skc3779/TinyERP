namespace App.Common.Validation.Validator
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseValidator : IValidator
    {
        public virtual bool Match(object value, object evaluator)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckRequire(object value)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckValueInRange(object value, object lowerBound, object upperBound)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckValueInCollection(object value, IEnumerable<object> values)
        {
            throw new NotImplementedException();
        }
    }
}