using System.Threading.Tasks;

namespace Oshxona.Data.Interfaces.Common
{
    public interface IDeleteable<T>
    {
        public Task DeleteAsync(int id);
    }
}
