using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio")]
    public AudioClip gameOverSFX;
    public AudioClip WinSFX;
    static public int currScore = 0;
    void Start()
    {

        LoadCurrScore();
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = currScore.ToString();
        Debug.Log("prevhigh " + HighScore.prevHighScore);
        Debug.Log("high " + HighScore.highScore);
        if (HighScore.prevHighScore>=HighScore.highScore)//当前局内没超过最高分
        {
            AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position); 
        }
        else
        {
            AudioSource.PlayClipAtPoint(WinSFX, Camera.main.transform.position);
            HighScore.SavePrevHighScore();
        }

    }

    private void LoadCurrScore()
    {
        currScore = PlayerPrefs.GetInt("CurrScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
