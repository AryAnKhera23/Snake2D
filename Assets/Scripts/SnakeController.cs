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
    [SerializeField] public int player = 1;
    private float nextUpdate;
    private float horizontal;
    private float vertical;
    private Vector2 direction;
    public List<Transform> segments;
    public float originalSpeed;
    


    
    private void Start()
    {
        originalSpeed = moveSpeed;
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
        if(player == 1)
        {
            horizontal = Input.GetAxisRaw("ADHorizontal");
            vertical = Input.GetAxisRaw("WSVertical");
        }
        else if (player == 2)
        {
            horizontal = Input.GetAxisRaw("ArrowHorizontal");
            vertical = Input.GetAxisRaw("ArrowVertical");
        }
        
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

    public void Shrink(int segmentCount)
    {
        if (segments.Count > 1) 
        {
            int removeCount = Mathf.Max(segments.Count - segmentCount, 1);
            for (int i = segments.Count - 1; i >= removeCount; i--)
            {
                Destroy(segments[i].gameObject);
                segments.RemoveAt(i);
            }
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
            
            if (player == 1)
            {
                SoundManager.Instance.Play(Sounds.PlayerDeath);
                gameOver.PlayerDead(1);
            }
            else if(player == 2)
            {
                SoundManager.Instance.Play(Sounds.PlayerDeath);
                gameOver.PlayerDead(2);
            }
            ResetGame();
            
        }
    }
}
