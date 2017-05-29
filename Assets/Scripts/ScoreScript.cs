﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Playercontroller controller;

    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = transform.FindChild("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = controller.Score.ToString();
	}
}
