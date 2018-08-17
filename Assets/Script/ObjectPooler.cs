using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    public GameObject pooledObject;
    public int pooledAmt;
    List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < pooledAmt; i++)
        {
            GameObject go = (GameObject)Instantiate(pooledObject);
            go.SetActive(false);
            pooledObjects.Add(go);
        }
	}
	public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject go = (GameObject)Instantiate(pooledObject);
        go.SetActive(false);
        pooledObjects.Add(go);
        return go;
    }
}
