using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    [SerializeField] protected Randomizer randomizer;
    public PowerUps powerUps;

    private void Start()
    {
        randomizer.RandomizePowerUp();
    }
}
