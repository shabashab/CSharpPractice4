namespace CSharpPractice3.Validators
{
    public interface IValidator<T>
    {
        public bool Validate(T value);
        public bool ValidateOrThrow(T value);
    }
}
