using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Shield : PowerUp
{
    
    protected override void ImplementPowerUp()
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        for (int i = 1; i < snakeController.segments.Count; i++)
        {
            snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        SegmentCollider.enabled = false;
        StartCoroutine(DisableShield());
    }

    private IEnumerator DisableShield()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5f);
        Debug.Log("5 seconds elapsed");
        for (int i = 1; i < snakeController.segments.Count; i++)
        {
            snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        SegmentCollider.enabled = true;
        Debug.Log("Colliders Activated");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ImplementPowerUp();
        randomizer.RandomizePowerUp();
    }
}
