using UnityEngine;


public abstract class TrapBase : MonoBehaviour
{
    protected abstract void OnEntityEnter(IEntity entity);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IEntity entity = collider.GetComponent<IEntity>();
        if (entity == null) return;
        OnEntityEnter(entity);
    }

}
