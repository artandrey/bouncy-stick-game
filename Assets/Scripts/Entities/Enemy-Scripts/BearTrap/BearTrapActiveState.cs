using UnityEngine;

public class BearTrapActiveState : BearTrapStateBase
{
    public override void OnEnabled(BearTrap context)
    {
        context.animator.SetBool("IsActivated", false);
        context.isActive = true;
        base.OnEnabled(context);
    }

    public override void OnPlayerEnter(Player player, BearTrap context)
    {
        player.DispatchDeath();
        var lockPoint = context.transform.position;
        player.transform.position = lockPoint + new Vector3(0, GetPlayerHeight(player) / 2, 0);
        context.SetState(new BearTrapActivatedState());
        base.OnPlayerEnter(player, context);
    }

    private float GetPlayerHeight(Player player)
    {
        var transform = player.transform;
        var collider = player.GetComponent<Collider2D>();
        return collider.bounds.size.y;

    }
}
