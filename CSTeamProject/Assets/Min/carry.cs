using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carry : MonoBehaviour
{
    [SerializeField] Transform Player1;
    bool carryon = false;
    void Start()
    {
        Player1 = GetComponent<Transform>();
       
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(carryon == false)
                {
                        transform.position = Player1.position + new Vector3(0, 2, 0);
                        carryon = true;
                }
                else
                transform.position = Player1.position + new Vector3(1, 0, 0);

            }

        }
    }
}
