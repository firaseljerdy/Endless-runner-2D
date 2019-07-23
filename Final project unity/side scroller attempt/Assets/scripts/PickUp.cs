using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public int score2_give;

    private AudioSource coinSound;

    public scoreManager thescoreManager;

    public LayerMask groundLayer;

    public Transform groundCheckPoint;

    public float groundCheckRadius;

    private bool isTouchingSmallGround;


    // Use this for initialization
    void Start () {

        thescoreManager = FindObjectOfType<scoreManager>();

        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();

       
	}
	
	// Update is called once per frame
	void Update () {

        isTouchingSmallGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if(isTouchingSmallGround)
        {
            this.gameObject.SetActive(false);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            thescoreManager.AddScore(score2_give);

            gameObject.SetActive(false);

            //to stop unity from cutting out effects
            if(coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }


        }


    }


}
