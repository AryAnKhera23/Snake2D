using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject scoreBoostPrefab;
    [SerializeField] private GameObject speedPrefab;
    [SerializeField] private GameObject massGainerPrefab;
    [SerializeField] private GameObject massBurnerPrefab;
    [SerializeField] private Consumables consumables;
    private int numberOfPowerUps = 3;

    private GameObject currentPowerUpInstance;
    private GameObject currentFoodInstance;

    public void RandomizePosition(GameObject consumable)
    {
        Bounds bounds = boundary.bounds;

        float randomXPosition = Random.Range(bounds.min.x, bounds.max.x);
        float randomYPosition = Random.Range(bounds.min.y, bounds.max.y);

        consumable.transform.position = new Vector3(Mathf.Round(randomXPosition), Mathf.Round(randomYPosition), 0);
        consumable.SetActive(true);
    }

    public void RandomizePowerUp()
    {
        if (currentPowerUpInstance != null)
        {
            Destroy(currentPowerUpInstance);
        }

        
        int powerup = Random.Range(0, numberOfPowerUps);

        GameObject powerUpPrefab = null;

        switch (powerup)
        {
            case 0:
                consumables.powerUps = PowerUps.Shield;
                powerUpPrefab = shieldPrefab;
                break;
            case 1:
                consumables.powerUps = PowerUps.ScoreBoost;
                powerUpPrefab = scoreBoostPrefab;
                break;
            case 2:
                consumables.powerUps = PowerUps.Speed;
                powerUpPrefab = speedPrefab;
                break;
        }

        currentPowerUpInstance = Instantiate(powerUpPrefab);
        RandomizePosition(currentPowerUpInstance);
    }

    public void RandomizeFood()
    {
        if (currentFoodInstance != null)
        {
            Destroy(currentFoodInstance);
        }

        int foodProbability = Random.Range(0, 100);

        GameObject foodPrefab = null;


        if(foodProbability < 65)
        {
            consumables.food = FoodType.MassGainer;
            foodPrefab = massGainerPrefab;
        }
        else if(foodProbability > 65)
        {
            consumables.food = FoodType.MassBurner;
            foodPrefab = massBurnerPrefab;
        }
        
        if(foodPrefab != null)
        {
            currentFoodInstance = Instantiate(foodPrefab);
            RandomizePosition(currentFoodInstance);
        }
        
    }
}
