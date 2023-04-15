using CSharpPractice3.Exceptions;
using System.Text.RegularExpressions;

namespace CSharpPractice3.Validators
{
    public class EmailValidator : IValidator<string>
    {
        private static EmailValidator? _instance = null;
        public static EmailValidator Instance { get => _instance == null ? _instance = new EmailValidator() : _instance; }

        private Regex validationPattern;

        private EmailValidator()
        {
            validationPattern = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        }

        public bool Validate(string email)
        {
            try
            {
                return ValidateOrThrow(email);

            } catch (EmailValidationException)
            {
                return false;
            }
        }

        public bool ValidateOrThrow(string email)
        {
            if (email.Length == 0)
                throw new EmailValidationException("Invalid email. Email length can't be zero");

            if (!validationPattern.IsMatch(email))
                throw new EmailValidationException("Invalid email. String doesn't match email format");

            return true;
        }
    }
}
