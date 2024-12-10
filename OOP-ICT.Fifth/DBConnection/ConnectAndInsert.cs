using System.Data.SqlClient;
using MongoDB.Bson;
using MongoDB.Driver;
using Spectre.Console;
//using System.Data.SqlClient;

namespace OOP_ICT.Fifth.DBConnection;

public class ConnectAndInsert
{
    public void Insert(string stringValue, int intValue)
    {
        string connectionString = "mongodb://localhost:27017";
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("casino");
        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("oop");

        var document = new BsonDocument
        {
            { "name", stringValue },
            { "winning", intValue }
        };

        collection.InsertOne(document);

        AnsiConsole.MarkupLine("[green]Info updated[/]");
    }
    
    public void SelectAll()
    {
        string connectionString = "mongodb://localhost:27017";
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("casino");
        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("oop");

        var filter = Builders<BsonDocument>.Filter.Empty;
        var documents = collection.Find(filter).ToList();

        foreach (var document in documents)
        {
            AnsiConsole.WriteLine(document.ToJson());
        }
    }
}