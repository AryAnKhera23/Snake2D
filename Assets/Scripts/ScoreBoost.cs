using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoost : PowerUp
{
    protected override void ImplementPowerUp(int player)
    {
        SoundManager.Instance.Play(Sounds.PowerUpPickup);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        if(player == 1)
        {
            snake1Controller.Grow(5);
        }
        else if(player == 2)
        {
            snake2Controller.Grow(5);
        }
        
    }
}
