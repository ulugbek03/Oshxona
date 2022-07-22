using System.Threading.Tasks;

namespace Oshxona.Data.Interfaces.Common
{
    public interface ICreateable<T>
    {
        public Task CreateAsync(T obj);
    }
}
