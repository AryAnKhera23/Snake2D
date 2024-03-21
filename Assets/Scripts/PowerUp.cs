using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PowerUps
{
    Shield,
    ScoreBoost,
    Speed
}
public abstract class PowerUp : Consumables
{
    
    [SerializeField] protected BoxCollider2D SegmentCollider;
    public new BoxCollider2D collider2D;
    public SpriteRenderer spriteRenderer;
    protected bool powerUpCompleted = true;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected abstract void ImplementPowerUp(int player);

    protected virtual void OnPowerUpCompleted()
    {
        powerUpCompleted = true;
    }

    protected virtual void OnPowerUpStart()
    {
        powerUpCompleted = false; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!powerUpCompleted)
        {
            return;
        }

        if(collision.TryGetComponent<SnakeController>(out snake1Controller))
        {
            if (snake1Controller.player == 1)
            {
                
                ImplementPowerUp(1);
            }
        }
        if (collision.TryGetComponent<SnakeController>(out snake2Controller))
        {
            if(snake2Controller.player == 2)
            {
                
                ImplementPowerUp(2);
            }
        }

    }

}
