using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gc : MonoBehaviour {

	public GameObject coin;
	public GameObject heart;
	public GameObject shield;
	public GameObject espinhoPrefab;
	//public GameObject heart;
	private GameObject[] spawnList;

	//public GameObject fruit;
	public float delay;
	private float timer;

	public float delayEspinhos;
	private float timerEspinhos;


	// Use this for initialization
	void Start () {
		spawnList = GameObject.FindGameObjectsWithTag ("spawn");
		timer = delay;
		timerEspinhos = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0) {
			int o = Random.Range (0, 3);
			GameObject spawn;
			int pos = Random.Range (0, 5);

			switch (o) {
			case 0:
				spawn = Instantiate (coin, spawnList[pos].transform.position, spawnList[pos].transform.localRotation);
				break;
			case 1:
				spawn = Instantiate (heart, spawnList[pos].transform.position, spawnList[pos].transform.localRotation);
				break;
			case 2:
				spawn = Instantiate (shield, spawnList [pos].transform.position, spawnList [pos].transform.localRotation);
				break;
			}
			timer = delay;
		} else {
			timer -= Time.deltaTime;
		}


		if (timerEspinhos <= 0) {
			int c;
			for (c = 0; c < 5; c++) {
				GameObject espinhoSpawn = Instantiate (espinhoPrefab, spawnList [c].transform.position, spawnList [c].transform.localRotation);
			}
			timerEspinhos = delay;
		} else {
			timerEspinhos -= Time.deltaTime;
		}

	}
}
