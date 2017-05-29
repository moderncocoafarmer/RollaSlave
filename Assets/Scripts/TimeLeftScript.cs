using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftScript : MonoBehaviour {

    private float TimeForLevel = 60;

    private GameObject endGameDialog;
    private Text timerText;
    bool endReached = false;

    private void Awake()
    {
        endGameDialog = GameObject.Find("UI");
    }

    // Use this for initialization
    void Start () {
        timerText = transform.FindChild("TimeLeftText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        TimeForLevel = Math.Max(0, TimeForLevel - Time.deltaTime);

        if (TimeForLevel == 0 && !endReached)
        {
            endReached = true;
            endGameDialog.SetActive(true);
            endGameDialog.GetComponent<EndGameScript>().ShowDialog("The newspapers will print the story of Nestle's involvement in child slavery.");
        }

        timerText.text = ((int)TimeForLevel).ToString();
    }
}
