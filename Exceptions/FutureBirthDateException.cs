using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice3.Exceptions
{
    public class FutureBirthDateException : BirthDateValidationException
    {
        public FutureBirthDateException() : base("Invalid birth date. You can't be born after today, can you?")
        { }
    }
}
