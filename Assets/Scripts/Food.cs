using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FoodType
{
    MassGainer,
    MassBurner
};
public class Food : Consumables
{
    [SerializeField] private FoodType type;
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private SnakeController snakeController;
    


    private void Start()
    {
        if(randomizer != null)
        {
            randomizer.RandomizePosition(gameObject);
        }
        else
        {
            Debug.Log("null randomizer");
        }
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == 3)
        {
            SoundManager.Instance.Play(Sounds.FoodPickup);
            snakeController.Grow(1);
            randomizer.RandomizePosition(gameObject);
        }
    }

}
