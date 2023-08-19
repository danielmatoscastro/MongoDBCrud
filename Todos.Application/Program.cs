using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Todos.Domain.Entities;
using Todos.Domain.Repositories;
using Todos.Infra.Options;
using Todos.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
BsonClassMap.RegisterClassMap<TodoList>(cm =>
{
    cm.AutoMap();
    cm.MapField("_items").SetElementName("Items");
});
builder.Services.Configure<MongoDBOptions>(builder.Configuration.GetSection(MongoDBOptions.MongoDB));
builder.Services.AddSingleton<MongoDBDataAccess>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoListRepository, TodoListRepository>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.MapGet("/", () => "raiz");
app.Run();
