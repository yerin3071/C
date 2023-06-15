using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    public int MoveSpeed = 8;
    public int JumpPower = 3;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float playerMove = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.D))
        {
            playerMove = MoveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerMove = -MoveSpeed * Time.deltaTime;
        }

        this.transform.Translate(new Vector3(playerMove, 0, 0));
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
}
