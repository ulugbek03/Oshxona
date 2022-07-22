using System.Threading.Tasks;

namespace Oshxona.Data.Interfaces.Common
{
    public interface IUpdateable<T>
    {
        public Task UpdateAsync(int id, T obj);
    }
}
