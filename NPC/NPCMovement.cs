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

    public bool isTalking;
    DialogManager manager;

    Rigidbody2D rb;
    [SerializeField] BoxCollider2D villagerZone;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<DialogManager>();

        walkTimeCounter = walkTime;
        stopTimeCounter = stopTime;
    }

    private void Update()
    {
        if (!manager.dialogActive)
        {
            isTalking = false;
        }

        if (isTalking)
        {
            StopWalking();
        }


        if (isWalking)
        {
            if (villagerZone != null)
            {
                if (transform.position.x < villagerZone.bounds.min.x ||
                    transform.position.x > villagerZone.bounds.max.x ||
                    transform.position.y < villagerZone.bounds.min.y ||
                    transform.position.y > villagerZone.bounds.max.y)
                {
                    StopWalking();
                }
            }

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
