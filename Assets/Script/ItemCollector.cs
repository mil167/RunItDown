using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour {

    public int pointValue;

    private ScoreManager sm;

    private AudioSource coinSFX;

	// Use this for initialization
	void Start () {
        sm = FindObjectOfType<ScoreManager>();

        coinSFX = GameObject.Find("Pickup_Coin").GetComponent<AudioSource>();   
	}
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            sm.UpdateScoreItem(pointValue);
            gameObject.SetActive(false);

            if(coinSFX.isPlaying) {
                coinSFX.Stop();
                coinSFX.volume = 0.3f;
                coinSFX.Play();
            }
            else {
                coinSFX.volume = 0.3f;
                coinSFX.Play();
            }
        }
    }
}
