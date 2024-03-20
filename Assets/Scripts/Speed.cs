using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : PowerUp
{
    protected override void ImplementPowerUp()
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        float originalSpeed = snakeController.moveSpeed;
        snakeController.moveSpeed += snakeController.moveSpeed;
        StartCoroutine(ResetSpeed(originalSpeed, 5f));
    }

    private IEnumerator ResetSpeed(float originalSpeed, float delay)
    {
        yield return new WaitForSeconds(delay);
        snakeController.moveSpeed = originalSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ImplementPowerUp();
        randomizer.RandomizePowerUp();
        
    }
}
