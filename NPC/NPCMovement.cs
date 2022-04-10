using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] bool isWalking;

    float walkTime = 2;
    float walkTimeCounter;

    float stopTime = 2;
    float stopTimeCounter;

    Vector2[] walkingDirection =
    {
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(-1, 0),
        new Vector2(0, -1)
    };
    int currentDirection;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        walkTimeCounter = walkTime;
        stopTimeCounter = stopTime;
    }

    private void Update()
    {
        if (isWalking)
        {
            rb.velocity = walkingDirection[currentDirection] * speed * Time.deltaTime;
            walkTimeCounter -= Time.deltaTime;
            if (walkTimeCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            stopTimeCounter -= Time.deltaTime;
            if (stopTimeCounter < 0)
            {
                StartWalking();
            }
        }
    }

    void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkTimeCounter = walkTime;
    }

    void StopWalking()
    {
        isWalking = false;
        stopTimeCounter = stopTime;
        rb.velocity = Vector2.zero;
    }
}
