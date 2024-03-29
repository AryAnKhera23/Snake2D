using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoost : PowerUp
{
    [SerializeField] private int scoreBoostAmount;
    protected override void ImplementPowerUp(int player)
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play(Sounds.PowerUpPickup);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        if(player == 1)
        {
            snake1Controller.Grow(scoreBoostAmount);
        }
        else if(player == 2)
        {
            snake2Controller.Grow(scoreBoostAmount);
        }
        
    }
}
