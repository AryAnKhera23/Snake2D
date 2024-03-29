using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FoodType
{
    MassGainer,
    MassBurner
};
public abstract class Food : Consumables
{
    protected new BoxCollider2D collider2D;
    protected SpriteRenderer spriteRenderer;


    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected abstract void ImplementFood(int player);
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<SnakeController>(out snake1Controller))
        {
            if(snake1Controller.player == 1)
            {
                ImplementFood(1);
            }
            
        }
        if (collision.TryGetComponent<SnakeController>(out snake2Controller))
        {
            if (snake1Controller.player == 2)
            {
                ImplementFood(2);
            }
        }
    }

}
