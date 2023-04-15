using System.Threading.Tasks;

namespace CSharpPractice4.Storage
{
    public interface IStorage<T>
    {
        Task Save(T value);
        Task<T> Load();
    }
}
