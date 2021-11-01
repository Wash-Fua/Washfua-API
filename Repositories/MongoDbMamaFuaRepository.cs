using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WashFua.Entities;

namespace WashFua.Repositories
{
    public class MongoDbMamaFuaRepository : IMamaFuaRepository
    {
        private const string databaseName = "washfua";
        private const string collectionName = "mamas";
        private readonly IMongoCollection<MamaFua> mamasCollection;
        private readonly FilterDefinitionBuilder<MamaFua> filterBuilder = Builders<MamaFua>.Filter;

        public MongoDbMamaFuaRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            mamasCollection = database.GetCollection<MamaFua>(collectionName);
        }

        public IEnumerable<MamaFua> GetMamaFuas()
        {
            return mamasCollection.Find(new BsonDocument()).ToList();
        }

        public MamaFua GetMamaFua(Guid id)
        {
            var filter = filterBuilder.Eq(mamaFua => mamaFua.Id, id);
            return mamasCollection.Find(filter).SingleOrDefault();
        }

        public void CreateMamaFua(MamaFua mamaFua)
        {
            mamasCollection.InsertOne(mamaFua);
        }

        public void UpdateMamaFua(MamaFua mamaFua)
        {
            var filter = filterBuilder.Eq(existingMamaFua => existingMamaFua.Id, mamaFua.Id);
            mamasCollection.ReplaceOne(filter, mamaFua);
        }

        public void DeleteMamaFua(Guid id)
        {
            var filter = filterBuilder.Eq(mamaFua => mamaFua.Id, id);
            mamasCollection.DeleteOne(filter);
        }
    }
}