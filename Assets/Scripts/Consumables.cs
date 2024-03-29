using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    [SerializeField] private float powerUpTimerDuration = 8f;
    [SerializeField] private float foodTimerDuration = 5f;
    [SerializeField] protected Randomizer randomizer;
    public PowerUps powerUps;
    public FoodType food;
    protected SnakeController snake1Controller;
    protected SnakeController snake2Controller;

    private void Start()
    {
        RandomizeConsumables();
        StartConsumableTimer();
    }

    private void RandomizeConsumables()
    {
        randomizer.RandomizeFood();
        randomizer.RandomizePowerUp();
    }

    private  void StartConsumableTimer()
    {
        StartPowerUpTimer();
        StartFoodTimer();
    }
    private void StartPowerUpTimer()
    {
        Invoke(nameof(PowerUpTimer), powerUpTimerDuration);
    }

    private void StartFoodTimer()
    {
        Invoke(nameof(FoodTimer), foodTimerDuration);
    }

    private void PowerUpTimer()
    {
        randomizer.RandomizePowerUp();
        StartPowerUpTimer();
    }

    private void FoodTimer()
    {
        randomizer.RandomizeFood();
        StartFoodTimer();
    }
}
