using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Dynamic;
using System.Reflection;
using Hama.Log.Dto;

namespace Hama.Log.Services;

public class LogHistoryService
{
    public string Field { get; set; }
    public object Value { get; set; }
    public LogHistoryService(string _Field, object _Value)
    {
        Field = _Field;
        Value = _Value;
    }

    public IEnumerable<object> ReadData(string EntityTypeName)
    {
        //var connectionString = "mongodb://admin:Admin123@192.168.1.15:27017/?authSource=admin";
        var connectionString = ClientInformation.MongoDBConnection + "?authSource=admin";

        // Create a client and connect to the MongoDB server
        var client = new MongoClient(connectionString);

        // Select the database
        var database = client.GetDatabase(ClientInformation.MongoDBDataBase);

        // Select the collection
        var collection = database.GetCollection<BsonDocument>("CrudDB");

        var filter1 = Builders<BsonDocument>.Filter.Eq($"Properties.logDto.Entity.{Field}", Value);
        var filter2 = Builders<BsonDocument>.Filter.Eq($"Properties.logDto.Entity._typeTag", $"{EntityTypeName}");
        var filter = filter1 & filter2;

        var data = collection.Find(filter).ToList().ToList();


        var filteredDocuments =

            data.Select(a => BsonSerializer.Deserialize<LogResultDTO>(a))
            .Select(a =>
            {

                dynamic result = new ExpandoObject();


                var entity = a.Properties.logDto.Entity;
                var LogMessage = a.Properties.logMessage;
                var userInformation = a.Properties.logDto.UserInformation;
                var client = a.Properties.logDto.Client;

                result.LogMessage = LogMessage;
                result.Client = client;
                result.UserInformation = userInformation;


                if (entity is IDictionary<string, object> expando)
                {
                    foreach (var kvp in expando)
                    {
                        ((IDictionary<string, object>)result)[kvp.Key] = kvp.Value;
                    }
                }
                else
                {
                    foreach (PropertyInfo prop in entity.GetType().GetProperties())
                    {
                        ((IDictionary<string, object>)result)[prop.Name] = prop.GetValue(entity);
                    }
                }

                result.CrudType = a.Properties.logDto.CrudType;
                foreach (PropertyInfo prop in client.GetType().GetProperties())
                {
                    ((IDictionary<string, object>)result)[prop.Name] = prop.GetValue(client);
                }

                foreach (PropertyInfo prop in userInformation.GetType().GetProperties())
                {
                    ((IDictionary<string, object>)result)[prop.Name] = prop.GetValue(userInformation);
                }


                return result;
            });

        return filteredDocuments;


    }
}
