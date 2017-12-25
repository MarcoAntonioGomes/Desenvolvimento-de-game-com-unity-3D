using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraitens : MonoBehaviour {
	private Rigidbody2D rb;

	private float atrito;
	public float atritoMaximo;
	public float atritoMinimo;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		atrito = Random.Range (atritoMinimo,atritoMaximo);
		rb.drag = atrito;
	}

	// Update is called once per frame
	void FixedUpdate () {

	}
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
