namespace dotnet_asp_todo.Interfaces;


public class TransientGuidService : ITransientGuid
{
    private readonly Guid Id;

    public TransientGuidService()
    {
        Id = Guid.NewGuid();
    }

    public Guid GetGuid()
    {
        return Id;
    }
}

public class ScopedGuidService : IScopedGuid
{
    private readonly Guid Id;

    public ScopedGuidService()
    {
        Id = Guid.NewGuid();
    }

    public Guid GetGuid()
    {
        return Id;
    }
}

public class SingletonGuidService : ISingletonGuid
{
    private readonly Guid Id;

    public SingletonGuidService()
    {
        Id = Guid.NewGuid();
    }

    public Guid GetGuid()
    {
        return Id;
    }
}
