using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] bool isfirstExit;
    public GameObject player1;
    public GameObject player2;
    public string nextLevelName;
    private bool player1InExit = false;
    private bool player2InExit = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1InExit = true;
        }
        if (collision.CompareTag("Player2"))
        {
            player2InExit = true;
        }

        if (player1InExit == true && player2InExit == true)
        {
            LoadNextLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1InExit = false;
        }
        if (collision.CompareTag("Player2"))
        {
            player2InExit = false;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}

