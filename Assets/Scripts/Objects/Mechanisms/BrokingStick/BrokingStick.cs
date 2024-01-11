using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokingStick : MonoBehaviour
{
    [SerializeField]
    private Sprite[] states;
    [SerializeField]
    private int currentBorkeIndex = 0;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D stickRigidbody;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        stickRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = states[currentBorkeIndex];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        OnBrokeIncrease();
    }

    private void OnBrokeIncrease()
    {
        if (currentBorkeIndex >= states.Length - 1)
        {
            OnBroken();
            return;
        }
        else
        {
            currentBorkeIndex++;
            spriteRenderer.sprite = states[currentBorkeIndex];
        }
    }

    private void OnBroken()
    {
        stickRigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}
