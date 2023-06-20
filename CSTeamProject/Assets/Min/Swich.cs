using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swich : MonoBehaviour
{
    public GameObject DangerWater1;
    
    void Start()
    {
      
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i =0; i < 100; i++)
            {
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
