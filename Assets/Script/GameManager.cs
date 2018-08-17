using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGen;
    private Vector3 platformStartPt;

    public PlayerMovement player;
    private Vector3 playerStartPt;

    private PlatformDestroyer[] platformList;

    private ScoreManager sm;

    public GameOverMenu gom;

	// Use this for initialization
	void Start () {
        platformStartPt = platformGen.position;

        playerStartPt = player.transform.position;

        sm = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameRestart()
    {
        sm.playerLoss = true;
        player.gameObject.SetActive(false);
        //StartCoroutine("GameRestartCo");

        gom.gameObject.SetActive(true);
    }

    public void Reset()
    {
        gom.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPt;
        platformGen.position = platformStartPt;
        player.gameObject.SetActive(true);

        sm.scoreCounter = 0;
        sm.playerLoss = false;
    }

    /*
    public IEnumerator GameRestartCo()
    {
        sm.playerLoss = true;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPt;
        platformGen.position = platformStartPt;
        player.gameObject.SetActive(true);

        sm.scoreCounter = 0;
        sm.playerLoss = false;
    }
    */
}
