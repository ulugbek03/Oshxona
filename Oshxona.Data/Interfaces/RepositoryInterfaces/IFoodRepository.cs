using Oshxona.Data.Interfaces.Common;
using Oshxona.Data.Models;

namespace Oshxona.Data.Interfaces.RepositoryInterfaces
{
    public interface IFoodRepository :
        ICreateable<Food>, IReadable<Food>, IUpdateable<Food>, IDeleteable<Food>
    {

    }
}
