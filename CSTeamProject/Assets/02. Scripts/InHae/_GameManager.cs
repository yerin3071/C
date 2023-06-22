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
    private int stageIndex=1;

    AudioSource audio;

    [SerializeField] AudioClip stageBgm;
    [SerializeField] AudioClip clearBgm;

    [SerializeField] GameObject gameOverPanel;

    
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    public void AudioPlay()
    {
        audio.Stop();
        audio.clip = clearBgm;
        audio.Play();
    }

    public void GameClear()
    {
        AudioPlay();
    }

    public int StageIndex
    {
        get => stageIndex; set => stageIndex = Mathf.Clamp(value, 1, 2);
    }

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


    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(stageIndex);
    }


}
