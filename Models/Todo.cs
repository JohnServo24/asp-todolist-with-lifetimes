namespace dotnet_asp_todo.Models;

public record Todo
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public bool IsDone { get; set; } = false;
    public Guid TransientGuid { get; set; }
    public Guid TransientGuid2 { get; set; }
    public Guid ScopedGuid { get; set; }
    public Guid ScopedGuid2 { get; set; }
    public Guid SingletonGuid { get; set; }
    public Guid SingletonGuid2 { get; set; }
}

// NOTE:
// { get; init; } by default
// init -> Set during initialization, but cannot be modified afterwards.
public record TodoAdd(string Content); // For POST body
public record TodoUpdate(string Content, bool IsDone); // For PUT body
