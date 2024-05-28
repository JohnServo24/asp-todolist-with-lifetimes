using dotnet_asp_todo.Context;
using dotnet_asp_todo.Services;
using dotnet_asp_todo.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<TodoContext>(
//         options =>
//             options.UseNpgsql(builder.Configuration.GetConnectionString("TodoContext")));
builder.Services.AddNpgsql<TodoContext>("Host=localhost;Username=postgres;Password=1234;Database=todolist");

builder.Services.AddScoped<TodoService>();

builder.Services.AddTransient<ITransientGuid, TransientGuidService>();
builder.Services.AddScoped<IScopedGuid, ScopedGuidService>();
builder.Services.AddSingleton<ISingletonGuid, SingletonGuidService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
