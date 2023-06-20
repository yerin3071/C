using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public int speed = 0;
    void Start()
    {
        
    }

   
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(x, 0, 0);
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
