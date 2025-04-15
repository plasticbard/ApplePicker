using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI scoreGT;
    //Apple Audio Effect
    public AudioClip appleSFX;
    public AudioClip bombSFX;
    
    public AudioClip highScoreSFX;

    // Start is called before the first frame update

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        // Set the score to 0 at the start
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse
        Vector3 mousePos2D = Input.mousePosition;
        //convert mouse position to world position
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        //set the position of the basket
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        int score = int.Parse(scoreGT.text);
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            Debug.Log("Apple caught!");
 
            score += 100; // Increment the score by 100
            scoreGT.text = score.ToString(); // Update the score text
            // Check if the score is greater than the high score
            if (score > HighScore.highScore)
            {
                HighScore.highScore = score; // Update the high score
                Debug.Log("New High Score: " + HighScore.highScore);

                // Play the high score sound effect
                AudioSource.PlayClipAtPoint(highScoreSFX, Camera.main.transform.position);
            }
            else
            {
                //play the apple sound effect
                AudioSource.PlayClipAtPoint(appleSFX, Camera.main.transform.position);
            }
        }
        else if (collidedWith.tag == "Bomb")
        {
            Destroy(collidedWith);
            Debug.Log("Bomb caught!");
            score -= 500;
            // Play the bomb sound effect
            AudioSource.PlayClipAtPoint(bombSFX, Camera.main.transform.position);
            if (score < 0)
            {
                score = 0;
            }
            scoreGT.text = score.ToString();
            ApplePicker applePicker = Camera.main.GetComponent<ApplePicker>();
            applePicker.AppleDestroyed(); // Notify the ApplePicker that an apple has been destroyed
        }
    }
    public void GameOver()
    {
        // Play the game over sound effect
        
        int score = int.Parse(scoreGT.text);
        if (score > HighScore.highScore)
        {
            HighScore.SaveHighScore();
        }
        SaveCurrScore();
        SceneManager.LoadScene("GameOver"); // Load the GameOver scene
        
    }

    private void SaveCurrScore()
    {
        PlayerPrefs.SetInt("CurrScore", int.Parse(scoreGT.text));
        PlayerPrefs.Save();
    }
}
