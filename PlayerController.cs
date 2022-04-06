using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 15;
    const string HORIZONTAL = "Horizontal";
    const string VERTICAL = "Vertical";
    float v;
    float h;

    [SerializeField] bool isWalking;
    [SerializeField] Vector2 lastDirection;
    // string WALKING_STATE = "Walking";

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isWalking = false;

        h = Input.GetAxisRaw(HORIZONTAL);
        v = Input.GetAxisRaw(VERTICAL);

        if (Mathf.Abs(h) > 0.5f || Mathf.Abs(v) > 0.5f)
        {
            isWalking = true;
            lastDirection = new Vector2(h * Time.deltaTime, v * Time.deltaTime);
            rb.velocity = lastDirection.normalized * speed;
        }

        if (!isWalking)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
