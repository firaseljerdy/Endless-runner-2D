using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    //publics
    public Text scoreText;

    public Text HighScoreText;

    public float score_count;

    public float highscore_count;

    public float pointsPerSec;

    public bool scoreIncreasing;

    public bool shouldDouble;


	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("HighScore")) 
        {

            highscore_count = PlayerPrefs.GetFloat("HighScore");

        }

	}
	
	// Update is called once per frame
	void Update () {

        if (scoreIncreasing) 
        {

            score_count += pointsPerSec * Time.deltaTime;

        }   

        if (score_count > highscore_count)
        {

            highscore_count = score_count;

            //store the high score
            PlayerPrefs.SetFloat("HighScore", highscore_count);

        }

        scoreText.text = "Score: " + Mathf.Round(score_count);

        HighScoreText.text = "Score: " + Mathf.Round(highscore_count);
    }

    public void AddScore(int pointsToAdd)
    {
        if (shouldDouble)
        {
            pointsToAdd *= 2;


        }

        score_count += pointsToAdd;


    }
}
