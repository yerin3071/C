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
            
            Destroy(DangerWater1);
        }
    }
}
