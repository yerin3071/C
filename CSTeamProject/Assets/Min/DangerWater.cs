using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerWater : MonoBehaviour
{
    Player_Move playerMove;
    void Start()
    {
        playerMove = FindObjectOfType<Player_Move>();
    }

    
    void Update()
    {

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어 태그
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<Player_Move>().Die();
        }
    }

   


}
