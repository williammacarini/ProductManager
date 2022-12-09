using System;

namespace ProductManager.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {
        }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidationException(message);
        }
    }
}
