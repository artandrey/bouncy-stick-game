using UnityEngine;

public class BearTrapActiveState : BearTrapStateBase
{
    public override void OnEnabled(BearTrap context)
    {
        context.animator.SetBool("IsActivated", false);
        context.isActive = true;
        base.OnEnabled(context);
    }

    public override void OnPlayerEnter(IEntity entity, BearTrap context)
    {
        var lockPoint = context.transform.position;
        entity.gameObject.transform.position = lockPoint + new Vector3(0, GetPlayerHeight(entity.gameObject) / 2, 0);
        entity.Die();
        context.SetState(new BearTrapActivatedState());
        base.OnPlayerEnter(entity, context);
    }

    private float GetPlayerHeight(GameObject gameObject)
    {
        var transform = gameObject.transform;
        var collider = gameObject.GetComponent<Collider2D>();
        return collider.bounds.size.y;

    }
}
