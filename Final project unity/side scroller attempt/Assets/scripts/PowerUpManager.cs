using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour {


    public Text muliplierScoreTxt;

    public Text removedObjectsTxt;

    private bool doublePoints;

    private bool safeMode;

    private bool powerupActivity;

    private float powerUpLengthCounter;

    private scoreManager theScoreManager;

    private PlatfromGenerator thePlatformGenerator;

    private float normalPointsPerSec;

    private float snowmanRate;

    private PlatformDestroyer[] snowmanList;

    private gameManager thegameManager;




    // Use this for initialization
    void Start () {

        theScoreManager = FindObjectOfType<scoreManager>();

        thePlatformGenerator = FindObjectOfType<PlatfromGenerator>();

        thegameManager = FindObjectOfType<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (powerupActivity)
        {
            powerUpLengthCounter -= Time.deltaTime;

            if (thegameManager.powerupReset)
            {
                powerUpLengthCounter = 0;

                thegameManager.powerupReset = false;

            }

            if (doublePoints)
            {

                theScoreManager.pointsPerSec = normalPointsPerSec * 2;
                theScoreManager.shouldDouble = true;

                muliplierScoreTxt.gameObject.SetActive(true);
                
                

            }

            if (safeMode)
            {

                thePlatformGenerator.randomSnowmanThreshold = 0;

                removedObjectsTxt.gameObject.SetActive(true);
                
            }

        

            if (powerUpLengthCounter <= 0)
            {
                theScoreManager.pointsPerSec = normalPointsPerSec;

                thePlatformGenerator.randomSnowmanThreshold = snowmanRate;

                powerupActivity = false;

                theScoreManager.shouldDouble = false;

                muliplierScoreTxt.gameObject.SetActive(false);

                removedObjectsTxt.gameObject.SetActive(false);



            }

        }


	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {

        doublePoints = points;

        safeMode = safe;

        powerUpLengthCounter = time;

        normalPointsPerSec = theScoreManager.pointsPerSec;

        snowmanRate = thePlatformGenerator.randomSnowmanThreshold;

        if (safeMode)
        {
            snowmanList = FindObjectsOfType<PlatformDestroyer>();

            for (int i = 0; i < snowmanList.Length; i++)
            {
                if (snowmanList[i].gameObject.name.Contains("snowman 3")) 
                {
                    snowmanList[i].gameObject.SetActive(false);
                }
            }
        }

        powerupActivity = true;

    }
}
