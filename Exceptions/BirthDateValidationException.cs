using System;

namespace CSharpPractice3.Exceptions
{
    public class BirthDateValidationException : Exception
    {
        public BirthDateValidationException(string message) : base(message)
        {
        }
    }
}
