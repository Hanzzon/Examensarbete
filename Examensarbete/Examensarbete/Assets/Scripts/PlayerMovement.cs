using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public GameObject player;

	private float playerSpeed;

	private bool isJumping;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -100.0f, 0);

		playerSpeed = 100.0f;

		isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
		

		Gravity ();

		Movement ();

		CheckGroundCollision ();
	}

	public void Jump()
	{

		if (isJumping == false) {
			
			player.transform.Translate (Vector3.up * Time.deltaTime * playerSpeed * 20);
			isJumping = true;
		}


	}

	void Gravity()
	{
		if (isJumping == true) {
			player.transform.Translate (Vector3.down * Time.deltaTime * playerSpeed);
			
		}
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

	private void Movement()
	{
		MoveRight ();
		MoveLeft ();
		//Jump ();
	}

	void CheckGroundCollision()
	{
		if (Physics.Raycast(player.transform.position, Vector3.down, 10)) {
			isJumping = false;
		}
	}

}
