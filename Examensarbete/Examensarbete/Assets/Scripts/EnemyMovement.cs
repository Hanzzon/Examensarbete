using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject Boss;
	private bool startMovement = true;
	private bool moveRight;

	// Use this for initialization
	void Start () {
		moveRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement()
	{

		if (moveRight == true) {
			Boss.transform.Translate (Vector3.right * Time.deltaTime * 50);
		} else {
			Boss.transform.Translate(Vector3.left * Time.deltaTime * 50);
		}
	}

	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.name == "LeftBlock") {
			moveRight = true;
		}
		else if(_collision.gameObject.name == "RightBlock")
		{
			moveRight = false;
		}

	}
}
