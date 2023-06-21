using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    public static _GameManager instance = null;
    Player_InHae player;
    Fish fish;
    public bool isGameOver;

    [SerializeField] GameObject gameOverPanel;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }


}
