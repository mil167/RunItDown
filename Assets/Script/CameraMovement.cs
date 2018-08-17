using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public PlayerMovement pm;
    private Vector3 prevPosition;
    private float distMove;
	// Use this for initialization
	void Start () {
        pm = FindObjectOfType<PlayerMovement>();
        prevPosition = pm.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        distMove = pm.transform.position.x - prevPosition.x;
        transform.position = new Vector3(transform.position.x + distMove, transform.position.y, transform.position.z);
        prevPosition = pm.transform.position;
        
	}
}
