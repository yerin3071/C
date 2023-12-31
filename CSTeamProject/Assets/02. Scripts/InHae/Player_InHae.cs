using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_InHae : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] float maxSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float distance;
    [SerializeField] LayerMask Ground;

    public bool playerDie;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine("Jump");
    }

    private void FixedUpdate()
    {
        if(!playerDie && !_GameManager.instance.isGameOver)
            Move();
    }

    private void Update()
    {
        if (!playerDie && !_GameManager.instance.isGameOver)
        {
            if (Mathf.Abs(rigid.velocity.x) > 0.3f)
                anim.SetBool("isRun", true);
            else
                anim.SetBool("isRun", false);

            if (Input.GetButtonUp("Horizontal"))
            {
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.01f, rigid.velocity.y);
            }

            if (Input.GetButton("Horizontal"))
            {
                sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            if (rigid.velocity.y < 0)
                LandingGround();
            else if (rigid.velocity.y == 0 && anim.GetBool("isJump"))
                LandingGround();

        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * x, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)                               
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);  
        else if (rigid.velocity.x < -maxSpeed)                         
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y); 
    }                                                                                               
                                                                                                    
    void LandingGround()                                                                            
    {
        anim.SetBool("isFall", true);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, distance);
        if (Physics2D.Raycast(transform.position, Vector2.down, distance, Ground))
        {
            anim.SetBool("isFall", false);
            anim.SetBool("isJump", false);
        }
    }   

    IEnumerator Jump()                                                                                
    {                                                                                                 
        while (true)                                                                                  
        {                                                                                             
            if (Input.GetKeyDown(KeyCode.W) && !anim.GetBool("isJump"))                           
            {                                                                                         
                rigid.AddForce(Vector2.up.normalized * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJump", true);
                yield return null;                                                                    
            }                                                                                         
            yield return null;
        }
    }

    public void dieEvent()
    {
        _GameManager.instance.GameOver();
    }

    public void Die()
    {
        playerDie = true;
        anim.SetTrigger("isDie");
    }
}
