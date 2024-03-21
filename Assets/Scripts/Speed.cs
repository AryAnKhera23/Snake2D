using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speed : PowerUp
{
    [SerializeField] TextMeshProUGUI speedText;
    bool isSpeedActive;
    protected override void ImplementPowerUp()
    {
        if(!isSpeedActive)
        {
            spriteRenderer.enabled = false;
            collider2D.enabled = false;
            speedText.enabled = true;
            float originalSpeed = snakeController.moveSpeed;
            snakeController.moveSpeed += snakeController.moveSpeed;
            isSpeedActive = true;
            StartCoroutine(ResetSpeed(originalSpeed, 5f));
        }
        
    }

    private IEnumerator ResetSpeed(float originalSpeed, float delay)
    {
        yield return new WaitForSeconds(delay);
        isSpeedActive = false;
        speedText.enabled = false;
        snakeController.moveSpeed = originalSpeed;
    }
}
