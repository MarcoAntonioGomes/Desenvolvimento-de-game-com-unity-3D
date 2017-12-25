using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class espinho : MonoBehaviour {
	private Rigidbody2D espinhoRB;

	private float atrito;
	public float atritoMaximo;
	public float atritoMinimo;
	public Vector2 posicao;
	public GameObject espinhoPrefab;

	// Use this for initialization
	void Start () {
		espinhoRB = GetComponent<Rigidbody2D> ();
		atrito = Random.Range (atritoMinimo,atritoMaximo);
		espinhoRB.drag = atrito;

		posicao = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
	void OnBecameInvisible(){
		//Instantiate (espinhoPrefab, posicao, transform.localRotation);
		pontuacao.pontos += 1;
		Destroy (this.gameObject);
	
	}
}
