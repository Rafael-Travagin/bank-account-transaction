using BankAccount.Api.Extesions;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
builder.AddAccountContext();
builder.AddMediator();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapAccountEndpoints();
app.Run();
