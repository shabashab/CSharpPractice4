using System;

namespace CSharpPractice3.Exceptions
{
    public class EmailValidationException : Exception
    {
        public EmailValidationException(string message) : base(message)
        {

        }
    }
}
