namespace dotnet_asp_todo.Interfaces;

public interface ITransientGuid
{
    Guid GetGuid();
}

public interface IScopedGuid
{
    Guid GetGuid();
}

public interface ISingletonGuid
{
    Guid GetGuid();
}
