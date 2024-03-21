using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoost : PowerUp
{
    protected override void ImplementPowerUp()
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        snakeController.Grow(5);
    }
}
