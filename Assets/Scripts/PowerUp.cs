using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PowerUps
{
    Shield,
    ScoreBoost,
    Speed
}
public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUps powerUps;
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private SnakeController snakeController;
    [SerializeField] private Sprite shieldGameSprite;
    [SerializeField] private Sprite scoreBoostGameSprite;
    [SerializeField] private Sprite speedGameSprite;
    [SerializeField] private BoxCollider2D SegmentCollider;
    SpriteRenderer spriteRenderer;
    private bool powerUpTriggered = false;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        RandomizePowerUp();
        StartCoroutine(RandomizePowerUpAfterDelay(7f));
    }

   
    private void ImplementPowerUp()
    {
        switch (powerUps)
        {
            case PowerUps.Shield:
                spriteRenderer.sprite = null;
                for(int i = 1; i < snakeController.segments.Count; i++)
                {
                    snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = false;
                }
                SegmentCollider.enabled = false;
                Invoke(nameof(DisableShield), 5f);
                break;

            case PowerUps.ScoreBoost:
                spriteRenderer.sprite = null;
                snakeController.Grow(5);
                break;

            case PowerUps.Speed:
                spriteRenderer.sprite = null;
                float originalSpeed = snakeController.moveSpeed;
                snakeController.moveSpeed += snakeController.moveSpeed;
                StartCoroutine(ResetSpeed(originalSpeed, 5f));
                break;

            default: 
                Debug.Log("No abilities");
                break;
        }
    }

    private IEnumerator ResetSpeed(float originalSpeed, float delay)
    {
        yield return new WaitForSeconds(delay);
        snakeController.moveSpeed = originalSpeed;
    }

    private IEnumerator RandomizePowerUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        powerUpTriggered = false;
        if (!powerUpTriggered)
        {
            RandomizePowerUp();
            powerUpTriggered = false;
        }
    }

    private void RandomizePowerUp()
    {
        int powerup = Random.Range(0, 3);

        if (powerup == 0)
        {
            powerUps = PowerUps.Shield;
            RandomizePosition(shieldGameSprite);
        }
        else if (powerup == 1)
        {
            powerUps = PowerUps.ScoreBoost;
            RandomizePosition(scoreBoostGameSprite);
        }
        else if (powerup == 2)
        {
            powerUps = PowerUps.Speed;
            RandomizePosition(speedGameSprite);
        }

    }

    private void RandomizePosition(Sprite powerUpSprite)
    {
        Bounds bounds = boundary.bounds;

        float randomXPoistion = Random.Range(bounds.min.x, bounds.max.x);
        float randomYPosition = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(randomXPoistion), Mathf.Round(randomYPosition), 0);
        spriteRenderer.sprite = powerUpSprite;
        boxCollider.enabled = true;
    }

    private void DisableShield()
    {
        for (int i = 1; i < snakeController.segments.Count; i++)
        {
            snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        SegmentCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            powerUpTriggered = true;
            boxCollider.enabled = false;
            ImplementPowerUp();
            StartCoroutine(RandomizePowerUpAfterDelay(7f));
        }
    }
}
