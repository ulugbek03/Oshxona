using Oshxona.Data.Constants;
using Oshxona.Data.Interfaces.RepositoryInterfaces;
using Oshxona.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Oshxona.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private const string _dbPath = DbConstants.CLIENT_DB_PATH;

        public async Task CreateAsync(Client obj)
        {
            var json = await File.ReadAllTextAsync(_dbPath);

            var clientList = JsonConvert.DeserializeObject<List<Client>>(json);

            int id = clientList.Count() > 0 ? clientList.Max(x => x.Id) + 1 : 1;
            obj.Id = id;

            if (clientList == null) clientList = new List<Client>();

            clientList.Add(obj);

            var newjson = JsonConvert.SerializeObject(clientList);

            await File.WriteAllTextAsync(_dbPath, newjson);
        }

        public async Task DeleteAsync(int id)
        {
            var json = await File.ReadAllTextAsync(_dbPath);

            var clientList = JsonConvert.DeserializeObject<List<Client>>(json);

            var deletedIndex = clientList.TakeWhile(x => x.Id != id).Count();

            clientList.RemoveAt(deletedIndex);

            var newjson = JsonConvert.SerializeObject(clientList);

            await File.WriteAllTextAsync(_dbPath, newjson);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var json = await File.ReadAllTextAsync(_dbPath);

            var clientList = JsonConvert.DeserializeObject<List<Client>>(json);

            return clientList;
        }

        public async Task<Client> GetAsync(int Id)
        {
            var json = await File.ReadAllTextAsync(_dbPath);

            var clientList = JsonConvert.DeserializeObject<List<Client>>(json);

            return clientList.FirstOrDefault(x => x.Id == Id);
        }

        public async Task UpdateAsync(int id, Client obj)
        {
            var json = await File.ReadAllTextAsync(_dbPath);

            var clientList = JsonConvert.DeserializeObject<List<Client>>(json);

            var updatedIndex = clientList.TakeWhile(x => x.Id != id).Count();

            clientList[updatedIndex] = obj;

            var newjson = JsonConvert.SerializeObject(clientList);

            await File.WriteAllTextAsync(_dbPath, newjson);
        }
    }
}
