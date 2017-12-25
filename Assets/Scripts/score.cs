using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
	public Text txt;

	// Use this for initialization
	void Start () {
		int highscore = PlayerPrefs.GetInt ("HighScore");
		int score = PlayerPrefs.GetInt ("Score");

		txt.text = "Score: " + score.ToString () + " \n" +
		"HighScore: " + highscore.ToString ();

		if (score > highscore) {
			txt.text+="\n New Record!";
			PlayerPrefs.SetInt ("HighScore",score);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
