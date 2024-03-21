using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject scoreBoostPrefab;
    [SerializeField] private GameObject speedPrefab;
    [SerializeField] private Consumables consumables;

    private GameObject currentPowerUpInstance;

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
            currentPowerUpInstance.GetComponent<SpriteRenderer>().enabled = false;
            currentPowerUpInstance.GetComponent<Collider2D>().enabled = false;
        }

        int powerup = Random.Range(0, 3);

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
}
