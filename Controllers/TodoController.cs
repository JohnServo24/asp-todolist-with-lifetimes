using Microsoft.AspNetCore.Mvc;
using dotnet_asp_todo.Models;
using dotnet_asp_todo.Services;

namespace dotnet_asp_todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Todo> GetAll() => _service.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Todo> Get(int id)
    {
        var todo = _service.Get(id);

        if (todo is null)
        {
            return NotFound();
        }

        return todo;
    }

    [HttpPost]
    public IActionResult Add(TodoAdd newTodo)
    {
        var todo = _service.Add(newTodo.Content);

        return CreatedAtAction(nameof(Get), new { Id = todo.Id }, todo);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = _service.Get(id);
        if (todo is null)
        {
            return NotFound();
        }

        _service.Delete(id, todo);

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TodoUpdate updatedTodo)
    {
        var todo = _service.Get(id);
        if (todo is null)
        {
            return NotFound();
        }

        _service.Update(id, updatedTodo);

        return Ok();
    }
}
