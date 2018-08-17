using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float accelRate;

    public float accelInterval;
    private float nextInterval;

    public float jumpHeight;

    private Rigidbody2D player;
    public bool isGround;
    public LayerMask whatIsGround;
    private Collider2D myCollider;

    public GameManager gm;

    private float moveSpeedStore;
    private float nextIntervalStore;
    private float accelIntervalStore;

    private bool canDoubleJump;

    public AudioSource jumpSFX;
    

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        moveSpeedStore = moveSpeed;
        nextIntervalStore = nextInterval;
        accelIntervalStore = accelInterval;
	}
	
	// Update is called once per frame
	void Update () {
        isGround = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if(transform.position.x > nextInterval)
        {
            nextInterval += accelInterval;
            accelInterval = accelInterval * accelRate;

            moveSpeed = moveSpeed * accelRate;
        }

        player.velocity = new Vector2(moveSpeed, player.velocity.y);
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) { return; }

            if (isGround) {
                player.velocity = new Vector2(player.velocity.x, jumpHeight);
                canDoubleJump = true;
                jumpSFX.volume = 0.3f;
                jumpSFX.Play();
            }
            if(!isGround && canDoubleJump)
            {
                player.velocity = new Vector2(player.velocity.x, jumpHeight);
                canDoubleJump = false;
                jumpSFX.volume = 0.3f;
                jumpSFX.Play();
            }
               
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "killBox")
         {
            gm.GameRestart();
            moveSpeed = moveSpeedStore;
            nextInterval = nextIntervalStore;
            accelInterval = accelIntervalStore;
         }
    }
}
