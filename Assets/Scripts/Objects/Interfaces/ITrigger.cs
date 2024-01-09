using System;

public interface ITrigger
{
    public Action OnActivated { get; }
    public Action OnDeactivated { get; }
}
