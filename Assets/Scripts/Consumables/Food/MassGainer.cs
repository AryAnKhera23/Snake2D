using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGainer : Food
{
    [SerializeField] private int growAmount;
    protected override void ImplementFood(int player)
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play(Sounds.MassGainerPickup);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        if (player == 1)
        {
            snake1Controller.Grow(growAmount);
        }
        else if(player == 2) 
        {
            snake2Controller.Grow(growAmount);
        }
    }
}
