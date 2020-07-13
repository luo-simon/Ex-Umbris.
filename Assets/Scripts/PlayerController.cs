using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public Vector2 moveVelocity;
    public bool canMove = true;

    public float lookDirection = 0;

    public bool hidden;
    private SpriteRenderer sprite;

    public bool hasKey = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (canMove) ProcessInputs();
        else moveVelocity = new Vector2(0, 0);

        SetAnimatorValues();

        if (hidden)
        {
            canMove = false;
            sprite.enabled = false;
        } else
        {
            canMove = true;
            sprite.enabled = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    void ProcessInputs()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void SetAnimatorValues()
    {
        anim.SetFloat("Horizontal", moveVelocity.x);
        anim.SetFloat("Vertical", moveVelocity.y);
        anim.SetFloat("Speed", moveVelocity.magnitude);

        if (moveVelocity != Vector2.zero)
        {
            float angle = Vector2.SignedAngle(Vector2.right, moveVelocity);
            anim.SetFloat("LookDirection", angle);
        }

    }
}
