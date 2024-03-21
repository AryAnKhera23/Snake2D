using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using UnityEngine;

public class Shield : PowerUp
{
    [SerializeField] TextMeshProUGUI shieldText;
    protected override void ImplementPowerUp()
    {
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
        shieldText.enabled = true;
        for (int i = 1; i < snakeController.segments.Count; i++)
        {
            snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        SegmentCollider.enabled = false;
        StartCoroutine(DisableShield());
    }

    private IEnumerator DisableShield()
    {

        yield return new WaitForSeconds(5f);

        shieldText.enabled = false;
        for (int i = 1; i < snakeController.segments.Count; i++)
        {
            snakeController.segments[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        SegmentCollider.enabled = true;

    }

}   
