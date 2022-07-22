using Oshxona.Data.Interfaces.Common;
using Oshxona.Data.Models;

namespace Oshxona.Data.Interfaces.RepositoryInterfaces
{
    public interface IOrderRepository
        : ICreateable<Order>, IReadable<Order>, IUpdateable<Order>, IDeleteable<Order>
    {
    }
}
