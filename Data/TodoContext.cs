using Microsoft.EntityFrameworkCore;
using dotnet_asp_todo.Models;

namespace dotnet_asp_todo.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}
