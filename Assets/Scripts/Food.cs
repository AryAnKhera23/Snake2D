using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FoodType
{
    MassGainer,
    MassBurner
};
public class Food : MonoBehaviour
{
    [SerializeField] private FoodType type;
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private SnakeController snakeController;


    private void Start()
    {
        RandomizePosition();
    }

    

    private void RandomizePosition()
    {
        Bounds bounds = boundary.bounds;

        float randomXPoistion = Random.Range(bounds.min.x, bounds.max.x);
        float randomYPosition = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(randomXPoistion), Mathf.Round(randomYPosition), 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == 3)
        {
            snakeController.Grow(1);
            RandomizePosition();
        }
    }

}
