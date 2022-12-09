using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Shared.Utils;
using Infra.Shared.WriteLogs.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Infra.Shared.WriteLogs
{
    public class WriteLogCollections : IWriteLogCollections
    {
        private readonly MongoClient _dbClient = null;

        public WriteLogCollections()
        {
            _dbClient = new MongoClient(Connections.GetConnectionStringMongoDb());
        }

        public void WriteError(string json)
        {
            try
            {
                var dbList = _dbClient.GetDatabase(Constants.NameBaseMongoDB());
                var collection = dbList.GetCollection<BsonDocument>("LogErrorAPI");

                BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(json);
                collection.InsertOne(document);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteRequest(string json)
        {
            try
            {
                var dbList = _dbClient.GetDatabase(Constants.NameBaseMongoDB());
                var collection = dbList.GetCollection<BsonDocument>("Request");

                BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(json);
                collection.InsertOne(document);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void WriteResponse(string json)
        {
            try
            {
                var dbList = _dbClient.GetDatabase(Constants.NameBaseMongoDB());
                var collection = dbList.GetCollection<BsonDocument>("Response");

                BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(json);
                collection.InsertOne(document);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}