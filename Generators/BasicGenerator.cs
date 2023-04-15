using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice4.Generators
{
    public abstract class BasicGenerator<T> : IGenerator<T>
    {
        public abstract T GenerateSingle();

        public IEnumerable<T> GenerateMany(uint count)
        {
            for(uint i = 0; i < count; i++)
                yield return GenerateSingle();
        }
    }
}
