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
    const string WALKING_STATE = "Walking";
    const string LH = "LastHorizontal";
    const string LV = "LastVertical";

    [SerializeField] bool isAttacking = false;
    const string ATTACKING_STATE = "Attaking";
    [SerializeField] float attackTime;
    float attackTimeCounter;

    public static bool playerIsCreated;

    public string nextPlaceName;

    public bool isTalking;

    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (!playerIsCreated)
        {
            playerIsCreated = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        isTalking = false;
    }

    private void Update()
    {
        if (isTalking)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        isWalking = false;

        h = Input.GetAxisRaw(HORIZONTAL);
        v = Input.GetAxisRaw(VERTICAL);

        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
            attackTimeCounter = attackTime;
            rb.velocity = Vector2.zero;
            anim.SetBool(ATTACKING_STATE, true);
        }

        if (isAttacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                isAttacking = false;
                anim.SetBool(ATTACKING_STATE, false);
            }
        }
        else
        {
            if (Mathf.Abs(h) > 0.5f || Mathf.Abs(v) > 0.5f)
            {
                isWalking = true;
                lastDirection = new Vector2(h * Time.deltaTime, v * Time.deltaTime);
                rb.velocity = lastDirection.normalized * speed;
            }
        }

        if (!isWalking)
        {
            rb.velocity = Vector2.zero;
        }

        anim.SetBool(WALKING_STATE, isWalking);
        anim.SetFloat(HORIZONTAL, h);
        anim.SetFloat(VERTICAL, v);
        anim.SetFloat(LH, lastDirection.x);
        anim.SetFloat(LV, lastDirection.y);
    }
}
