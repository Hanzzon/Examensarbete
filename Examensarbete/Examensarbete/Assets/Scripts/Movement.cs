using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	public LayerMask playerMask;
	public Transform groundCheck;

	private Rigidbody2D rb;
	private Animator anim;

	private float speed = 100f;
	private float jumpForce = 200f;

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
        //CheckPlayerDeath();

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, playerMask);

		if (!isGrounded)
			anim.SetBool ("Jump", true);
		else if(isGrounded)
			anim.SetBool ("Jump", false);

		Move (hInput);
	}

	public void Move(float horizontalInput)
	{
		Vector2 moveVel = rb.velocity;
		moveVel.x = horizontalInput * speed;
		rb.velocity = moveVel;

		anim.SetFloat ("Speed", Mathf.Abs (horizontalInput));

		if(horizontalInput < 0)
			transform.localScale = new Vector3 (-60, 60, 1);
		else if(horizontalInput > 0)
			transform.localScale = new Vector3 (60, 60, 1);
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

	void CheckPlayerDeath()
	{
		if (rb.transform.position.y < -50) {
			rb.transform.position = new Vector3 (-58, 26, 0);
			print ("Dead");
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            print("WATER!");
            rb.transform.position = new Vector3(-58, 26, 0);
        }

        if (coll.gameObject.name == "MissionPortal")
        {
            //if (levelIndex == 1)
            //{
                SceneManager.LoadScene("BuildBridge");
                //print(levelIndex);
            //}
            //else if (levelIndex == 2)
            //{
                //SceneManager.LoadScene("MissionDefeatEnemy");
            //}
        }
    }
}
