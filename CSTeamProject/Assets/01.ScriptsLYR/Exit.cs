using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static bool player1InExit = false;
    public static bool player2InExit = false;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1InExit = true;
            anim.SetBool("isOpen", true);
            Debug.Log( "플레이어 1 불값"+player1InExit);
            CheckBothPlayersInExit();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            anim.SetBool("isOpen", false);
            player1InExit = false;
        }
    }

    public void CheckBothPlayersInExit()
    {
        if (player1InExit == true && player2InExit == true)
        {
            Debug.Log("문이 열려요!");
            LoadNextLevel();
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(_GameManager.instance.StageIndex);
    }
}
