using TempApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TempApi.Services
{
    public class TempService
    {
        private readonly IMongoCollection<TempItem> _tempItem;

        public TempService(ITempDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tempItem = database.GetCollection<TempItem>(settings.TempCollectionName);
        }

        public List<TempItem> Get() =>
            _tempItem.Find(tempItem => true).ToList();

        public TempItem Get(string id) =>
            _tempItem.Find<TempItem>(tempItem => tempItem.Id == id).FirstOrDefault();

        public TempItem Create(TempItem tempIn)
        {
            _tempItem.InsertOne(tempIn);
            return tempIn;
        }

        public void Update(string id, TempItem tempIn) =>
            _tempItem.ReplaceOne(tempItem => tempItem.Id == id, tempIn);

        public void Remove(TempItem tempIn) =>
            _tempItem.DeleteOne(tempItem => tempItem.Id == tempIn.Id);

        public void Remove(string id) =>
            _tempItem.DeleteOne(tempItem => tempItem.Id == id);
    }
}