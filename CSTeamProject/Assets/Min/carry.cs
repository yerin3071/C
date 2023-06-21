using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carry : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    bool carryon = false;
    
    
    void Update()
    {
      if(carryon == true)          
        transform.position = Player1.transform.position + new Vector3(0,1,0) ;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(carryon == false)
                {
                        carryon = true;
                }

                else if(carryon == true)
                {
                    transform.position = Player1.transform.position + new Vector3(2, 0, 0);
                    carryon = false;
                }

            }

        }
    }
}
