using System;
using System.Collections.Generic;

namespace CSharpPractice4.Generators
{
    public interface IGenerator<T>
    {
        T GenerateSingle();
        IEnumerable<T> GenerateMany(UInt32 count);
    }
}
