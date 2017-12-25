using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontuacao : MonoBehaviour {

	public static int pontos;
	public static int vidas;
	public Text txt;
	public Text vidastxt;


	// Use this for initialization
	void Start () {
		pontos = 0;
		vidas = 3;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Score: " + pontos.ToString ();
		vidastxt.text = "Lives: " + vidas.ToString ();
	}
}
