using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGainer : Food
{
    protected override void ImplementFood(int player)
    {
        SoundManager.Instance.Play(Sounds.MassGainerPickup);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        if (player == 1)
        {
            snake1Controller.Grow(1);
        }
        else if(player == 2) 
        {
            snake2Controller.Grow(1);
        }
    }
}
