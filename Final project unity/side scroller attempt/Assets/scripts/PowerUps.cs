using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{

    public bool doublePoints;

    public bool safeMode;

    public float powerupLength;

    private PowerUpManager thepowerupManager;

    public Light pointlight;

    public AudioSource powerupSound;







    // Use this for initialization
    void Start()
    {


        thepowerupManager = FindObjectOfType<PowerUpManager>();

    }


    void Awake()
    {

        int powerupSelector = Random.Range(0, 2);

        switch (powerupSelector)
        {
            case 0:
                doublePoints = true;
                safeMode = !doublePoints;



                break;

            case 1:
                safeMode = true;
                doublePoints = !safeMode;

                break;

        }

        if (!safeMode)
        {
            pointlight.color = Color.blue;

        }


    }

    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            thepowerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);

            powerupSound.Play();
        }


            gameObject.SetActive(false);

        
    }
}


