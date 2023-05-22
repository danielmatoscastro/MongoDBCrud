namespace Todos.Infra.Options;

public class MongoDBOptions
{
    public const string MongoDB = "MongoDB";

    public string ConnectionString { get; set; } = null!;
    public string Database { get; set; } = null!;
}