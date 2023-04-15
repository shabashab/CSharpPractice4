using CSharpPractice3.Exceptions;
using System;

namespace CSharpPractice3.Validators
{
    public class BirthDateValidator : IValidator<DateTime>
    {
        private static BirthDateValidator? _instance = null;
        public static BirthDateValidator Instance { get => _instance == null ? _instance = new BirthDateValidator() : _instance; }

        private BirthDateValidator()
        { }

        public bool Validate(DateTime value)
        {
            try
            {
                return ValidateOrThrow(value);

            } catch (BirthDateValidationException)
            {
                return false;
            }
        }

        public bool ValidateOrThrow(DateTime value)
        {
            DateTime now = DateTime.Now;

            if (value > now)
                throw new BirthDateValidationException("Invalid birth date. You can't be born after today, can you?");

            int age = (int)((now - value).TotalDays / 365.25);

            if (age > 135)
                throw new AgeTooOldException();

            return true;
        }
    }
}
