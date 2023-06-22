using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class _GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public static _GameManager instance = null;
    public bool isGameOver;
    private float time = 120f;

    [SerializeField] GameObject gameOverPanel;

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (time > 0)
        {
            if (time < 10)
            {
                timeText.color = Color.red;
            }
            time -= Time.deltaTime;

            timeText.text = $"{time:N2}";
        }
        else
            GameOver();
    }

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

    public void Restart()
    {
        
    }


}
