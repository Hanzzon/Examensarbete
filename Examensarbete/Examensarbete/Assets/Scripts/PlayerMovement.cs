using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public GameObject player;

	private float playerSpeed;

	private bool isJumping;

	private Vector2 jumping = new Vector2(0, 4000);

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, -100.0f, 0);

		playerSpeed = 100.0f;

		isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {

		CheckPlayerDeath ();

		Movement ();

		CheckGroundCollision ();
	}

	public void Jump()
	{

		if (isJumping == false) {
			this.GetComponent<Rigidbody> ().velocity = Vector2.zero;
			this.GetComponent<Rigidbody> ().AddForce (jumping);
			isJumping = true;
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
		if (Physics.Raycast(player.transform.position, Vector3.down, 15)) {
			isJumping = false;
		}
	}

	void CheckPlayerDeath()
	{
		if (player.transform.position.y < -300) {
			player.transform.position = new Vector3 (-100, 30, 100);
		}
	}

}
