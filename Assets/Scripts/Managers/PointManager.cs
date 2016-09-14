using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Prime31.MessageKit;

public class PointManager : Singleton<PointManager> {
	protected PointManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
    private int totalPoints;

	public void AddPoints(int points) {
        totalPoints += points;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        print("##### Totalpoints: " + totalPoints);
    }
}