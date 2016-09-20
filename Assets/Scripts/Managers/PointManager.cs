using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;
using UnityEngine.UI;

public class PointManager : Singleton<PointManager> {
	protected PointManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
    private int totalPoints;
    private Text scoreText;

    public void Awake () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

	public void AddPoints(int points) {
        totalPoints += points;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        scoreText.text = "Score: " + totalPoints;
    }
}