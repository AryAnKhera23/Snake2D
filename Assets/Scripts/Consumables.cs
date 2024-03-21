using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    [SerializeField] private float timerDuration = 6f;
    [SerializeField] protected Randomizer randomizer;
    public PowerUps powerUps;
    private Coroutine timerCoroutine;

    private void Start()
    {
        randomizer.RandomizePowerUp();
        StartTimer();
    }

    private void StartTimer()
    {
        
        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(timerDuration);
        randomizer.RandomizePowerUp();
        StartTimer();
    }

    
    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    
    private void OnDestroy()
    {
        StopTimer();
    }
}
