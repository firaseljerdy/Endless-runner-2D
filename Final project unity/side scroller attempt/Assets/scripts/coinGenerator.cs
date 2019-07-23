using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour {

    public poolManager coinPool;

    public float distanceBetweenCoins;



    public void SpawnCoins(Vector3 S_positon)
    {

        GameObject coin1 = coinPool.GetPooledObject();

        coin1.transform.position = S_positon;

        coin1.SetActive(true);


        GameObject coin2 = coinPool.GetPooledObject();

        coin2.transform.position = new Vector3(S_positon.x - distanceBetweenCoins, S_positon.y, S_positon.z);

        coin2.SetActive(true);


        GameObject coin3 = coinPool.GetPooledObject();

        coin3.transform.position = new Vector3(S_positon.x + distanceBetweenCoins, S_positon.y, S_positon.z);

        coin3.SetActive(true);


    }

 

}
