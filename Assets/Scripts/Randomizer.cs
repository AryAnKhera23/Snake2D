using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private Shield shield;
    [SerializeField] private ScoreBoost scoreBoost;
    [SerializeField] private Speed speed;
    [SerializeField] private Consumables consumables;

    public void RandomizePosition(GameObject consumable)
    {
        Bounds bounds = boundary.bounds;

        float randomXPoistion = Random.Range(bounds.min.x, bounds.max.x);
        float randomYPosition = Random.Range(bounds.min.y, bounds.max.y);

        consumable.transform.position = new Vector3(Mathf.Round(randomXPoistion), Mathf.Round(randomYPosition), 0);
        consumable.SetActive(true);
    }

    public void RandomizePowerUp()
    {
        int powerup = Random.Range(0, 3);

        if (powerup == 0)
        {
            consumables.powerUps = PowerUps.Shield;
            shield.spriteRenderer.enabled = true;
            shield.collider2D.enabled = true;
            RandomizePosition(shield.gameObject);
        }
        else if (powerup == 1)
        {
            scoreBoost.spriteRenderer.enabled = true;
            scoreBoost.collider2D.enabled = true;
            consumables.powerUps = PowerUps.ScoreBoost;
            RandomizePosition(scoreBoost.gameObject);
        }
        else if (powerup == 2)
        {
            speed.spriteRenderer.enabled = true;
            speed.collider2D.enabled = true;
            consumables.powerUps = PowerUps.Speed;
            RandomizePosition(speed.gameObject);
        }

    }
}
