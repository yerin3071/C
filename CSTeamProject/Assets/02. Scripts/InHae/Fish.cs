using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;
    Vector2 dir;
    [SerializeField] float maxSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (Mathf.Abs(rigid.velocity.x) > 0.3f)
            anim.SetBool("isRun", true);
        else
            anim.SetBool("isRun", false);

        if (Input.GetButtonUp("Horizontal2"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.01f, rigid.velocity.y);
        }

        if (Input.GetButton("Horizontal2"))
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal2") == -1;
        }
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal2");

        rigid.AddForce(Vector2.right * x, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    }

}
