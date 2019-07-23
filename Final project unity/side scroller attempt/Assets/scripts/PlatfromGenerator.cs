using System.Collections;
using UnityEngine;

public class PlatfromGenerator : MonoBehaviour {

    //publics
    public GameObject thePlatform;

    public Transform generationPoint;

    public float distance;

    public float dBetweenPlat_Min;

    public float dBetweenPlat_Max;

    public Transform _maxHeightPoint;

    public float maxHeightChange;
    
    public poolManager[] theObjectPools;

    public float randomCoinThreshold;

    public float randomSnowmanThreshold;

    public poolManager pool;

    public float powerupHeight;

    public poolManager powerupPool;

    public float powerupThreshold;


    //privates
    private float platformWidth;

    private int platformSelector;

    private float[] PlatformWidths;

    private float _minHeight;

    private float _maxHeight;

    private float heightChange;

    private coinGenerator coinGen;

    // Use this for initialization
    void Start () {

        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        PlatformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {

            PlatformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x - 2;

        }

        _minHeight = transform.position.y;

        _maxHeight = _maxHeightPoint.position.y;

        coinGen = FindObjectOfType<coinGenerator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < generationPoint.position.x) 
        {
            distance = Random.Range(dBetweenPlat_Min, dBetweenPlat_Max);

            //randomly pick a platform
            platformSelector = Random.Range(0, theObjectPools.Length);

            //random height and width between platforms
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > _maxHeight)
            {
                heightChange = _maxHeight;

            }
            else if (heightChange < _minHeight)
            {

                heightChange = _minHeight;
            }

            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();

                newPowerup.transform.position = transform.position + new Vector3(distance / 2f, Random.Range(0f, powerupHeight), 0f);

                newPowerup.SetActive(true);


            }


            transform.position = new Vector3(transform.position.x + (PlatformWidths[platformSelector] / 2) + distance, 
                heightChange,
                transform.position.z);
  

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //generating coins on the platforms
            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                coinGen.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
            }

            //generating snowmen on the platforms
            if (Random.Range(0f, 100f) < randomSnowmanThreshold) 
            {
                GameObject newSnowman = pool.GetPooledObject();

                float snowmanXpos = Random.Range(-PlatformWidths[platformSelector] / 2f + 0.5f, PlatformWidths[platformSelector] / 2f - 0.5f);

                Vector3 snowmanPosition = new Vector3(snowmanXpos, -1.25f, 0f);

                newSnowman.transform.position = transform.position + snowmanPosition;

                newSnowman.transform.rotation = transform.rotation;

                newSnowman.SetActive(true);
            }


            transform.position = new Vector3(transform.position.x + (PlatformWidths[platformSelector] / 2),
               transform.position.y,
               transform.position.z);

        }

	}
}
