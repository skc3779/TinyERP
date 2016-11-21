using System;
using App.Common.Validation;

namespace App.Common.Helpers
{
    public class ValidationHelper
    {
        public static ValidationException Validate(object obj)
        {
            IValidationException ex = new ValidationException();
            if (obj == null) {
                ex.Add(new ValidationError);
            }
        }
    }
}
