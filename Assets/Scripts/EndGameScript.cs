using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

    public Playercontroller controller;
    private GameObject endGameDialog;

	// Use this for initialization
	void Start ()
    {
        endGameDialog = transform.Find("EndGameDialog").gameObject;
        endGameDialog.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (controller.Score == controller.MaxPickupsCount)
        {
            ShowDialog("Congratulations, you have hidden all of the child slaves from public view.");
        }
	}

    public void ShowDialog(string text)
    {
        endGameDialog.SetActive(true);
        endGameDialog.transform.Find("Description").GetComponent<Text>().text = text;
    }
}
