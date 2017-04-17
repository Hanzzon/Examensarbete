using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;

    private float speed = 70f;
    private bool turn;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        turn = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < 19.06499f)
            transform.position = new Vector3(transform.position.x, 19.06499f, 0f); 

        if (turn)
            Move(1);

        if (transform.position.x > 200)
        {
            turn = false;
            Move(-1);           
        }
        else if (transform.position.x < -200)
            turn = true;
    }

    public void Move(float horizontalInput)
    {
        Vector2 moveVel = rb.velocity;
        moveVel.x = horizontalInput * speed;
        rb.velocity = moveVel;

        if (horizontalInput < 0)
            transform.localScale = new Vector3(-30, 30, 0);
        else if (horizontalInput > 0)
            transform.localScale = new Vector3(30, 30, 0);
    }
}
