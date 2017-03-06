﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public GameObject player;

	private float playerSpeed;

	private bool isJumping;

	private Vector2 jumping = new Vector2(0, 2000);

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -100.0f, 0);

		playerSpeed = 150.0f;

		isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		Movement ();

		CheckGroundCollision ();
	}

	public void Jump()
	{

		//if (isJumping == false) {
			
		//	player.transform.Translate (Vector3.up * Time.deltaTime * playerSpeed * 12);
		//	isJumping = true;
		//}

		this.GetComponent<Rigidbody> ().velocity = Vector2.zero;
		this.GetComponent<Rigidbody> ().AddForce (jumping);

	}

	public void MoveLeft()
	{
		if (Input.GetKey("a")) {
			player.transform.Translate(Vector3.left * Time.deltaTime * playerSpeed);
		}
	}

	public void MoveRight()
	{

		if (Input.GetKey("d")) {
			player.transform.Translate (Vector3.right * Time.deltaTime * playerSpeed);
		}
	}

	public void MoveRightAndroid()
	{
		player.transform.Translate (Vector3.right * Time.deltaTime * playerSpeed);

	}

	private void Movement()
	{
		MoveRight ();
		MoveLeft ();
	}

	void CheckGroundCollision()
	{
		if (Physics.Raycast(player.transform.position, Vector3.down, 10)) {
			isJumping = false;
		}
	}

}