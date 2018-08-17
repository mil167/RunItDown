using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameObject platform;
    public Transform gp;
    public float platformDist;
    private float platformWidth;
    public float pdMin;
    public float pdMax;

    private int platformSelect;
    private float[] randPlatformWidth;

    private float minHeight;
    public Transform maxHeightPt;
    private float maxHeight;
    public float maxHeightDiff;
    private float heightDiff;

    private CoinGenerator cg; 

    public ObjectPooler[] op;

    public float randCoinThreshold;

	// Use this for initialization
	void Start () {
        randPlatformWidth = new float[op.Length];
        for(int i = 0; i < randPlatformWidth.Length; i++)
        {
            randPlatformWidth[i] = op[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPt.position.y;

        cg = FindObjectOfType<CoinGenerator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < gp.position.x)
        {
            platformDist = Random.Range(pdMin, pdMax);

            platformSelect = Random.Range(0, op.Length);

            heightDiff = transform.position.y + Random.Range(maxHeightDiff,-maxHeightDiff);

            if(heightDiff > maxHeight)
            {
                heightDiff = maxHeight;
            }
            else if(heightDiff < minHeight)
            {
                heightDiff = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (randPlatformWidth[platformSelect]/2) + platformDist, heightDiff, transform.position.z);
            
            GameObject newPlatform = op[platformSelect].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            
            if(Random.Range(0f,100f) < randCoinThreshold)
            {
                cg.CreateCoins(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (randPlatformWidth[platformSelect] / 2), transform.position.y, transform.position.z);

        }
	}
}
