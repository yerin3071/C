using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] float maxSpeed;
    [SerializeField] float distance;
    [SerializeField] LayerMask Water;
    private bool isWater;
        
    public bool fishDie;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (isWater && !_GameManager.instance.isGameOver) 
            Move();
    }

    private void Update()
    {
        if (!fishDie && !_GameManager.instance.isGameOver)
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

            ExitWater();
        }
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal2");
        float y = Input.GetAxisRaw("Vertical2");

        rigid.velocity = new Vector3(x, y, 0);
        rigid.velocity *= maxSpeed;
        
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    }

    void ExitWater()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.red, distance);
        if (!Physics2D.Raycast(transform.position, Vector2.down, distance, Water))
        {
            rigid.gravityScale = 2f;
            isWater = false;
        }
        else
        {
            rigid.gravityScale = 0;
            isWater = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && !isWater)
        {
            Die();
        }
    }

    public void dieEvent()
    {
        _GameManager.instance.GameOver();
    }

    public void Die()
    {
        fishDie = true;
        anim.SetTrigger("isDie");
    }
}
