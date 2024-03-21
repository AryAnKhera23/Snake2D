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
    private Coroutine powerUpTimerCoroutine;
    private Coroutine foodTimerCoroutine;
    protected SnakeController snake1Controller;
    protected SnakeController snake2Controller;

    private void Start()
    {
        randomizer.RandomizeFood();
        randomizer.RandomizePowerUp();
        StartPowerUpTimer();
        StartFoodTimer();
    }

    private void StartPowerUpTimer()
    {
        powerUpTimerCoroutine = StartCoroutine(PowerUpTimerCoroutine());
    }

    private void StartFoodTimer()
    {
        foodTimerCoroutine = StartCoroutine(FoodTimerCoroutine());
    }

    private IEnumerator PowerUpTimerCoroutine()
    {
        yield return new WaitForSeconds(powerUpTimerDuration);
        randomizer.RandomizePowerUp();
        StartPowerUpTimer();
    }

    private IEnumerator FoodTimerCoroutine()
    {
        yield return new WaitForSeconds(foodTimerDuration);
        randomizer.RandomizeFood();
        StartFoodTimer();
    }

    private void StopPowerUpTimer()
    {
        if (powerUpTimerCoroutine != null)
        {
            StopCoroutine(powerUpTimerCoroutine);
        }
    }

    private void StopFoodTimer()
    {
        if (foodTimerCoroutine != null)
        {
            StopCoroutine(foodTimerCoroutine);
        }
    }

    private void OnDestroy()
    {
        StopPowerUpTimer();
        StopFoodTimer();
    }
}
