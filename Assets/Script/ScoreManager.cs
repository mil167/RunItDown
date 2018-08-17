using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCounter;
    public float highScoreCounter;

    public float pointsPerSec;
    public bool playerLoss;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("high score"))
        {
            highScoreCounter = PlayerPrefs.GetFloat("high score");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!playerLoss)
        {
            scoreCounter += pointsPerSec * Time.deltaTime;
        }

        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("high score", highScoreCounter);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCounter);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCounter);

	}

    public void UpdateScoreItem(int points)
    {
        scoreCounter += points;
    }
}
