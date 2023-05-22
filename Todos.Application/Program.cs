using Todos.Domain.Repositories;
using Todos.Infra.Options;
using Todos.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBOptions>(builder.Configuration.GetSection(MongoDBOptions.MongoDB));
builder.Services.AddSingleton<MongoDBDataAccess>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();
