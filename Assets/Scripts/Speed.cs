using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speed : PowerUp
{
    [SerializeField] private TextMeshProUGUI speedText;
    
    protected override void ImplementPowerUp(int player)
    {
       SoundManager.Instance.Play(Sounds.PowerUpPickup);
       spriteRenderer.enabled = false;
       collider2D.enabled = false;
       speedText.enabled = true;
       if(player == 1) {
           IncreaseSpeed(snake1Controller);
       }
       else if(player == 2) {
           IncreaseSpeed(snake2Controller);
       }
    }

    private void IncreaseSpeed(SnakeController snakeController)
    {
        snakeController.moveSpeed += snakeController.moveSpeed;
        Invoke(nameof(ResetSpeed), 5f);
    }

    private void ResetSpeed()
    {
        if(speedText != null) {
            speedText.enabled = false;
        }

        if(snake1Controller != null)
        {
            snake1Controller.moveSpeed = snake1Controller.originalSpeed;
        }
        if(snake2Controller != null)
        {
            snake2Controller.moveSpeed = snake2Controller.originalSpeed;
        }
                  
    }

    private void OnDestroy()
    {
        ResetSpeed();
    }
}
