using System;

public interface ITrigger
{
    public Action OnActivated { get; set; }
    public Action OnDeactivated { get; set; }

    public bool IsActivated();
}
