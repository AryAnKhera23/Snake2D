using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Transform segmentPrefab;
    [SerializeField] private GameOverController gameOver;
    private float nextUpdate;
    private float horizontal;
    private float vertical;
    private Vector2 direction;
    public List<Transform> segments;
    


    
    private void Start()
    {
        
        segments = new List<Transform>
        {
            transform
        };
    }

    private void Update()
    { 
        ProcessInput();    
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }

    private void ProcessInput()
    {
        horizontal = Input.GetAxisRaw("ADHorizontal");
        vertical = Input.GetAxisRaw("WSVertical");
        if (vertical > 0)
        {
            direction = Vector2.up;
        }
        else if (vertical < 0)
        {
            direction = Vector2.down;
        }
        else if (horizontal > 0)
        {
            direction = Vector2.right;
        }
        else if (horizontal < 0)
        {
            direction = Vector2.left;
        }
    }

    private void ProcessMovement()
    {
        if (Time.time < nextUpdate)
        {
            return;
        }

        Vector2 headPosition = transform.position;

        Vector3 position = transform.position;
        position.x += direction.x;
        position.y += direction.y;
        transform.position = position;

        for (int i = segments.Count - 1; i > 1; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        if(segments.Count > 1)
        {
            segments[1].position = headPosition;
        }
        

        nextUpdate = Time.time + (1f / (moveSpeed * speedMultiplier));

    }


    public void Grow(int segmentCount)
    {
        
        Vector3 spawnPosition = transform.position - (Vector3)direction.normalized * 0.5f; 

        for (int i = 0; i < segmentCount; i++)
        {
            Vector3 adjustedSpawnPosition = spawnPosition - (i + 1) * 0.5f * (Vector3)direction.normalized;
            Transform segment = Instantiate(segmentPrefab, adjustedSpawnPosition, Quaternion.identity);
            segments.Add(segment);
        }
    }

    private void ResetGame()
    { 
        segments.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 6)
        {
            ResetGame();
            gameOver.PlayerDead();
        }
    }
}
