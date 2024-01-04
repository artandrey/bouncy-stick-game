using UnityEngine;


public abstract class TrapBase : MonoBehaviour
{
    protected abstract void OnPlayerEnter(Player player);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.PLYAER))
        {
            Player player = collider.GetComponent<Player>();
            OnPlayerEnter(player);
        }
    }

}
