using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using UnityEngine;

public class Shield : PowerUp
{
    [SerializeField] private GameObject shieldText;
    protected override void ImplementPowerUp(int player)
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play(Sounds.PowerUpPickup);
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        shieldText.SetActive(true);
        if (player == 1)
        {
            EnableShield(snake1Controller);
        }
            
        else if (player == 2)   
        {
            EnableShield(snake2Controller);
        }

        Invoke(nameof(DisableShield), 5f);
        
    }

    private void EnableShield(SnakeController snakeController)
    {
        for (int i = 1; i < snakeController.segments.Count; i++)
        {
            snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        SegmentCollider.enabled = false;
    }

    private void DisableShield()
    {
        if(shieldText != null)
        {
            shieldText.SetActive(false);
        }
        
        if(snake1Controller != null)
        {
            for (int i = 1; i < snake1Controller.segments.Count; i++)
            {
                snake1Controller.segments[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        if(snake2Controller != null)
        {
            for (int i = 1; i < snake2Controller.segments.Count; i++)
            {
                snake2Controller.segments[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        SegmentCollider.enabled = true;

    }
    private void OnDestroy()
    {
        DisableShield();
    }

}   