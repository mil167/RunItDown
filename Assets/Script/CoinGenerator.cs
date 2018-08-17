using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    public float coinDist;
   
    public void CreateCoins(Vector3 position)
    {
        GameObject coinObj1 = coinPool.GetPooledObject();
        coinObj1.transform.position = position;
        coinObj1.SetActive(true);

        GameObject coinObj2 = coinPool.GetPooledObject();
        coinObj2.transform.position = new Vector3(position.x - coinDist, position.y, position.z);
        coinObj2.SetActive(true);

        GameObject coinObj3 = coinPool.GetPooledObject();
        coinObj3.transform.position = new Vector3(position.x + coinDist, position.y, position.z);
        coinObj3.SetActive(true);
    }
}
