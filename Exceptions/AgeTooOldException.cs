using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice3.Exceptions
{
    public class AgeTooOldException : BirthDateValidationException
    {
        public AgeTooOldException() : base("Invalid age. Age can't be more than 135 (that's too old)")
        { }
    }
}
