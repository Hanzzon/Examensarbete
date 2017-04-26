using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public static Movement instance = null;

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
        //if (instance != null)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    instance = this;
        //    GameObject.DontDestroyOnLoad(gameObject);
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        //}
        
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, playerMask);

		if (!isGrounded)
			anim.SetBool ("Jump", true);
		else if(isGrounded)
			anim.SetBool ("Jump", false);

		Move (hInput);

        if (Input.GetButtonDown("Fire3"))
        {
            if (isGrounded)
                rb.velocity += jumpForce * Vector2.up;
        }

        float XOne = Input.GetAxis("Horizontal");
        
        if(XOne > 0)
        {
            Move(1f);
        }
        else if(XOne < 0)
        {
            Move(-1f);
        }
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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            print("WATER!");
            //GameObject obj = GameObject.Find("MapManager");
            //MapManager script = obj.GetComponent<MapManager>();

            //rb.transform.position = script.SpawnPosition();

            rb.transform.position = MapManager.signPosition[MapManager.missionsPlayed - 1];
        }

        if (coll.gameObject.tag == "Bridge")
        {
            MapManager.missionsPlayed++;
            print("Mission played: " + MapManager.missionsPlayed);
            SceneManager.LoadScene("BridgeBuilding");
        }
        else if (coll.gameObject.tag == "Boss")
        {
            MapManager.missionsPlayed++;
            print("Mission played: " + MapManager.missionsPlayed);
            SceneManager.LoadScene("BossBattle");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Crate")
        {           
            Destroy(col.gameObject);

            GameObject obj = GameObject.Find("BridgeManager");
            BridgeManager script = obj.GetComponent<BridgeManager>();
            script.AddPlayerScore();
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Boss")
        {
            GameObject obj = GameObject.Find("BossManager");
            BossManager script = obj.GetComponent<BossManager>();
            script.AddPlayerScore();

            rb.velocity += jumpForce * Vector2.up;
        }
    }
}
