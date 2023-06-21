using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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
    }
    void Move()
    {
        float playerMove = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            playerMove = MoveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerMove = -MoveSpeed * Time.deltaTime;
        }

        this.transform.Translate(new Vector3(playerMove, 0, 0));
    }
}
