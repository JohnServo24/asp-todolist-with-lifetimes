using dotnet_asp_todo.Models;
using dotnet_asp_todo.Context;
using dotnet_asp_todo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_asp_todo.Services;

public class TodoService(
    TodoContext _context,
    ITransientGuid _transient1,
    ITransientGuid _transient2,
    IScopedGuid _scoped1,
    IScopedGuid _scoped2,
    ISingletonGuid _singleton1,
    ISingletonGuid _singleton2
)
{
    public IEnumerable<Todo> GetAll() => _context.Todos
        .AsNoTracking()
        .ToList();

    public Todo? Get(int id) => _context.Todos
        .AsNoTracking()
        .SingleOrDefault(t => t.Id == id);

    public Todo Add(string content)
    {
        var todo = _context.Todos.Add(new Todo
        {
            Content = content,
            TransientGuid = _transient1.GetGuid(),
            TransientGuid2 = _transient2.GetGuid(),
            ScopedGuid = _scoped1.GetGuid(),
            ScopedGuid2 = _scoped2.GetGuid(),
            SingletonGuid = _singleton1.GetGuid(),
            SingletonGuid2 = _singleton2.GetGuid()
        });
        _context.SaveChanges();

        return todo.Entity;
    }

    public void Delete(int id, Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
    }

    public void Update(int id, TodoUpdate updatedTodo)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null) throw new InvalidOperationException("Todo not found.");

        todo.Content = updatedTodo.Content;
        todo.IsDone = updatedTodo.IsDone;
        _context.SaveChanges();
    }
}
