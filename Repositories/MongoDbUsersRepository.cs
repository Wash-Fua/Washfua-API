using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WashFua.Entities;

namespace WashFua.Repositories
{
    public class MongoDbUsersRepository : IUsersRepository
    {
        private const string databaseName = "washfua";
        private const string collectionName = "users";
        private readonly IMongoCollection<User> usersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        public MongoDbUsersRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }

        public IEnumerable<User> GetUsers()
        {
            return usersCollection.Find(new BsonDocument()).ToList();
        }

        public User GetUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return usersCollection.Find(filter).SingleOrDefault();
        }

        public void CreateUser(User user)
        {
            usersCollection.InsertOne(user);
        }

        public void UpdateUser(User user)
        {
            var filter = filterBuilder.Eq(existinguser => existinguser.Id, user.Id);
            usersCollection.ReplaceOne(filter, user);
        }

        public void DeleteUser(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            usersCollection.DeleteOne(filter);
        }
    }
}