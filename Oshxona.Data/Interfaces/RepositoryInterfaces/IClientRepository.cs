using Oshxona.Data.Interfaces.Common;
using Oshxona.Data.Models;

namespace Oshxona.Data.Interfaces.RepositoryInterfaces
{
    public interface IClientRepository :
        ICreateable<Client>, IReadable<Client>, IUpdateable<Client>, IDeleteable<Client>
    {

    }
}
