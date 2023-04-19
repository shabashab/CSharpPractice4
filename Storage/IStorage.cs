using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpPractice4.Storage
{
    public interface IStorage<T>
    {
        Task Save(IEnumerable<T> value);
        IAsyncEnumerable<T> Load();
    }
}
