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
    public class FoodRepository : IFoodRepository
    {
        public async Task CreateAsync(Food obj)
        {
            var json = await File.ReadAllTextAsync(DbConstants.FOOD_DB_PATH);

            var foodlist = JsonConvert.DeserializeObject<List<Food>>(json);

            int id = foodlist.Count() > 0 ? foodlist.Max(x => x.Id) + 1 : 1;
            obj.Id = id;

            if (foodlist == null) foodlist = new List<Food>();
            foodlist.Add(obj);

            var newjson = JsonConvert.SerializeObject(foodlist);

            await File.WriteAllTextAsync(DbConstants.FOOD_DB_PATH, newjson);
        }

        public async Task DeleteAsync(int id)
        {
            var json = await File.ReadAllTextAsync(DbConstants.FOOD_DB_PATH);

            var foodlist = JsonConvert.DeserializeObject<List<Food>>(json);

            var deletedIndex = foodlist.TakeWhile(x => x.Id != id).Count();

            foodlist.RemoveAt(deletedIndex);

            var newjson = JsonConvert.SerializeObject(foodlist);

            await File.WriteAllTextAsync(DbConstants.FOOD_DB_PATH, newjson);
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            var json = await File.ReadAllTextAsync(DbConstants.FOOD_DB_PATH);

            var foodlist = JsonConvert.DeserializeObject<List<Food>>(json);

            return foodlist;
        }

        public async Task<Food> GetAsync(int Id)
        {
            var json = await File.ReadAllTextAsync(DbConstants.FOOD_DB_PATH);

            var foodlist = JsonConvert.DeserializeObject<List<Food>>(json);

            return foodlist.Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task UpdateAsync(int id, Food obj)
        {
            var json = await File.ReadAllTextAsync(DbConstants.FOOD_DB_PATH);

            var foodlist = JsonConvert.DeserializeObject<List<Food>>(json);

            var updatedIndex = foodlist.TakeWhile(x => x.Id != id).Count();

            foodlist[updatedIndex] = obj;

            var newjson = JsonConvert.SerializeObject(foodlist);

            await File.WriteAllTextAsync(DbConstants.FOOD_DB_PATH, newjson);
        }
    }
}
