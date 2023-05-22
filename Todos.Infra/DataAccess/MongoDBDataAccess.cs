using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Todos.Infra.Options;

public class MongoDBDataAccess
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;

    private readonly IOptions<MongoDBOptions> _mongoDBOptions;

    public MongoDBDataAccess(IOptions<MongoDBOptions> mongoDBOptions)
    {
        _mongoDBOptions = mongoDBOptions;

        _mongoClient = new MongoClient(mongoDBOptions.Value.ConnectionString);
        _mongoDatabase = _mongoClient.GetDatabase(mongoDBOptions.Value.Database);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName) => _mongoDatabase.GetCollection<T>(collectionName);
}