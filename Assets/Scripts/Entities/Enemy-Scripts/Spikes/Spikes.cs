
public class Spikes : TrapBase
{
    protected override void OnEntityEnter(IEntity entity)
    {
        entity.Die();
    }
}
