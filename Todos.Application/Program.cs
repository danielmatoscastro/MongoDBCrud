using Todos.Infra.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBOptions>(builder.Configuration.GetSection(MongoDBOptions.MongoDB));
builder.Services.AddSingleton<MongoDBDataAccess>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();
