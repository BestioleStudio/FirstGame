using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
	private Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Start () {

		playerRigidbody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			//transform.Translate (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);
			playerRigidbody.velocity = new Vector2(Input.GetAxisRaw ("Horizontal") * moveSpeed, playerRigidbody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
		{
			//transform.Translate (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f);
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) 
		{
			playerRigidbody.velocity = new Vector2 (0f, playerRigidbody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
		{
			playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, 0f);
		}


	}
}
