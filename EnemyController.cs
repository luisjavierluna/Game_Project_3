using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] Vector2 direction;
    [SerializeField] bool isWalking;

    float walkTime = 2;
    float walkTimeCounter;

    float stopTime = 2;
    float stopTimeCounter;

    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";

    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        walkTimeCounter = walkTime * Random.Range(0.5f, 1.5f);
        stopTimeCounter = stopTime * Random.Range(0.5f, 1.5f);
    }

    private void Update()
    {
        if (isWalking)
        {
            walkTimeCounter -= Time.deltaTime;
            rb.velocity = direction * speed;
            if (walkTimeCounter < 0)
            {
                isWalking = false;
                walkTimeCounter = walkTime;
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            stopTimeCounter -= Time.deltaTime;
            if (stopTimeCounter < 0)
            {
                isWalking = true;
                stopTimeCounter = stopTime;
                direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            }
        }
        anim.SetFloat(HORIZONTAL, direction.x);
        anim.SetFloat(VERTICAL, direction.y);
    }
}
