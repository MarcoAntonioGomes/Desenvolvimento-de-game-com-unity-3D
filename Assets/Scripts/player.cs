using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    public float velocidade;
	public float dir;
	public bool flipX;
	private Animator anim;

	public float invDelay;
	public float invTimer;
	public bool hit;
	public float inc;
    public GameObject somMoeda;
    public GameObject somVida;
    public GameObject somDano;
    public GameObject somEscudo;

    void Start () {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
		dir = 1;
		anim = GetComponent<Animator> ();
		hit = false;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (Input.GetMouseButtonDown(0))
        {
			//Flip direction
			dir *=-1;
            flipX = !flipX;
            playerSprite.flipX = flipX;
			velocidade += inc;
        }

		if (hit) {
			if (invTimer < 0) {
				hit = false;
				anim.SetBool ("Hit",false);
			} else {
				invTimer -= Time.deltaTime;
			}
		}

        playerRb.velocity = new Vector2(velocidade*dir, playerRb.velocity.y);
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "espinhos" && !hit)
        {
            pontuacao.vidas--;
            somDano.GetComponent<AudioSource>().Play();
            if (pontuacao.vidas == 0)
            {
                SceneManager.LoadScene("gameover");
                PlayerPrefs.SetInt("Score", pontuacao.pontos);
                //gameover
            }
            else
            {
                //5 sec invensibility
                anim.SetBool("Hit", true);
                hit = true;
                invTimer = invDelay;
            }
        }
    }

   

	void OnTriggerEnter2D(Collider2D colisao){
		if (colisao.gameObject.tag == "espinhos" && !hit) {
			pontuacao.vidas--;
            somDano.GetComponent<AudioSource>().Play();
            if (pontuacao.vidas == 0) {
				SceneManager.LoadScene ("gameover");
				PlayerPrefs.SetInt ("Score",pontuacao.pontos);
				//gameover
			} else {
				//5 sec invensibility
				anim.SetBool ("Hit",true);
				hit = true;
				invTimer = invDelay;
			}
			Destroy (colisao.gameObject);
			
		} else if (colisao.gameObject.tag == "coin") {
			pontuacao.pontos += 100;
            somMoeda.GetComponent<AudioSource>().Play();
            Destroy (colisao.gameObject);
		} else if (colisao.gameObject.tag == "heart") {
			pontuacao.vidas++;
            somVida.GetComponent<AudioSource>().Play();
            Destroy (colisao.gameObject);
		}else if (colisao.gameObject.tag == "shield") {
            somEscudo.GetComponent<AudioSource>().Play();
            anim.SetBool ("Hit",true);
			hit = true;
			invTimer = invDelay;
			Destroy (colisao.gameObject);
		}

	}

}
















