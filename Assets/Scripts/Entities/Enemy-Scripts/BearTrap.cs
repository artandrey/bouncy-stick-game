using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : TrapBase
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void OnPlayerEnter(Player player)
    {
        animator.SetTrigger("Activate");
        player.DispatchDeath();
        var lockPoint = this.transform.position;
        player.transform.position = lockPoint + new Vector3(0, GetPlayerHeight(player) / 2, 0);
    }

    private float GetPlayerHeight(Player player)
    {
        var transform = player.transform;
        var collider = player.GetComponent<Collider2D>();
        return collider.bounds.size.y;

    }
}
