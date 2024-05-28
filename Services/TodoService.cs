using dotnet_asp_todo.Models;
using dotnet_asp_todo.Context;
using dotnet_asp_todo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_asp_todo.Services;

public class TodoService
{
    private readonly TodoContext _context;
    private readonly ITransientGuid _transient1;
    private readonly ITransientGuid _transient2;
    private readonly IScopedGuid _scoped1;
    private readonly IScopedGuid _scoped2;
    private readonly ISingletonGuid _singleton1;
    private readonly ISingletonGuid _singleton2;

    public TodoService(
            TodoContext context,
            ITransientGuid transientGuid,
            ITransientGuid transientGuid2,
            IScopedGuid scopedGuid,
            IScopedGuid scopedGuid2,
            ISingletonGuid singletonGuid,
            ISingletonGuid singletonGuid2)
    {
        _context = context;
        _transient1 = transientGuid;
        _transient2 = transientGuid2;
        _scoped1 = scopedGuid;
        _scoped2 = scopedGuid2;
        _singleton1 = singletonGuid;
        _singleton2 = singletonGuid2;
    }

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
