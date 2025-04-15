using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    static public int highScore = 1000;
    static public int prevHighScore = 0;
    static public bool isNewHighScore = false;
    void Start()
    {
        //SaveHighScore();
        //SavePrevHighScore();
        LoadHighScore();   
    }

    private void LoadHighScore()
    {
        highScore=PlayerPrefs.GetInt("HighScore", 0);
        prevHighScore = PlayerPrefs.GetInt("prevHighScore", 0);

    }
    static public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
    static public void SavePrevHighScore()
    {
        PlayerPrefs.SetInt("prevHighScore", highScore);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt=this.GetComponent<TextMeshProUGUI>();
        
        gt.text= "High Score: " + highScore.ToString();

        if (highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore.highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", HighScore.highScore);
        }
    }
}
