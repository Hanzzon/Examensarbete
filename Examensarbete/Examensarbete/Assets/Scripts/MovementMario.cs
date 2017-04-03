using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMario : MonoBehaviour {

	public LayerMask playerMask;
	public Transform groundCheck;

	private Rigidbody2D rb;
	private Animator anim;

	private float speed = 100f;
	private float jumpForce = 100f;

	private float hInput = 0;
	private float groundRadius = 0.2f;

	public bool isGrounded = false;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, playerMask);

		if (!isGrounded)
			anim.SetBool ("Jump", true);
		else if(isGrounded)
			anim.SetBool ("Jump", false);

		Move (hInput);

		if(Input.GetKey("a"))
		{
			Move (-1f);
		}
	}

	public void Move(float horizontalInput)
	{
		Vector2 moveVel = rb.velocity;
		moveVel.x = horizontalInput * speed;
		rb.velocity = moveVel;

		anim.SetFloat ("Speed", Mathf.Abs (horizontalInput));

		if(horizontalInput < 0)
			transform.localScale = new Vector3 (-20, 20, 1);
		else if(horizontalInput > 0)
			transform.localScale = new Vector3 (20, 20, 1);
	}

	public void StartMoving(float horizontalInput)
	{
		hInput = horizontalInput;
	}

	public void Jump()
	{
		if (isGrounded)
			rb.velocity += jumpForce * Vector2.up;
	}
}
