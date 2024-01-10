
using UnityEngine;

public interface IEntity
{
    public GameObject gameObject { get; }
    public void Die();
}
