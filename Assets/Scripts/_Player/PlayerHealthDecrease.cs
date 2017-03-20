﻿using System.Collections;
using UnityEditor;
using UnityEngine;
using Managers;

public class PlayerHealthDecrease : MonoBehaviour {

    [Range(0, 50)]
    public int dropPerFrame = 20;

    private Health playersHealth;

    private int frame = 0;
    public int waitDelayInFrames = 100;

    private void Awake()
    {
        playersHealth = gameObject.GetComponent<Health>();
    }

    private void Start()
    {
        StartCoroutine(StartHealthDegrees());
    }

    IEnumerator StartHealthDegrees() {
        yield return new WaitUntil(() => frame >= waitDelayInFrames);

        print("Playerhealth = " + playersHealth.hitPoints);

        if (playersHealth.hitPoints > 0) {
            playersHealth.hitPoints = playersHealth.hitPoints - dropPerFrame;
        }

        //reset the frame and restart the Coroutine
        frame = 0;
        StartCoroutine(StartHealthDegrees());
    }

    void Update() {
        if (frame <= waitDelayInFrames)
        {
            frame++;
        }
    }
}