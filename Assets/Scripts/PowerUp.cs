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
    
    [SerializeField] protected SnakeController snakeController;
    [SerializeField] protected BoxCollider2D SegmentCollider;
    public new BoxCollider2D collider2D;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected abstract void ImplementPowerUp();

  
}
