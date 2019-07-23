using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolManager : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;

    private void Start()
    {

        pooledObjects = new List<GameObject>();

        for (int j = 0; j < pooledAmount; j++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy)
            {

                return pooledObjects[i];

            }

        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;

    }

}

