using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swich : MonoBehaviour
{
    public GameObject DangerWater1;
    private SpriteRenderer spr;
    public Sprite changeimage;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2") || collision.CompareTag("Player1"))
        {
            for(int i =0; i < 100; i++)
            {
                spr.sprite = changeimage;
                Destroy(DangerWater1.gameObject);
               // DangerWater1.transform.localScale -= new Vector3(0, 0.01f, 0);
              
            }


            
        }
    }

    IEnumerator DelayTime()
    {

       yield return new WaitForSeconds(10f);
    }
}
