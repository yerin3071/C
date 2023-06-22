using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E1 : Exit
{
    public new void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            player2InExit = true;
            Debug.Log( "�÷��̾� 2 �Ұ�"+player2InExit);
            CheckBothPlayersInExit();
        }
    }   
    public new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            player2InExit = false;
        }
    }
    public new void CheckBothPlayersInExit()
    {
        if (player1InExit == true && player2InExit == true)
        {
            Debug.Log("��");
            LoadNextLevel();
        }
    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}