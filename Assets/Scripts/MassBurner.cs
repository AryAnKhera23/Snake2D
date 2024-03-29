using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBurner : Food
{
    [SerializeField] private int shrinkAmount;
    protected override void ImplementFood(int player)
    {
        SoundManager.Instance.Play(Sounds.MassBurnerPickup);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        if (player == 1)
        {
            snake1Controller.Shrink(shrinkAmount);
        }
        else if (player == 2)
        {
            snake2Controller.Shrink(shrinkAmount);
        }
        
    }
}
