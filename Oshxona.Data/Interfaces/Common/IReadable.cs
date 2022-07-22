using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oshxona.Data.Interfaces.Common
{
    public interface IReadable<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetAsync(int Id);
    }
}
