using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBuildBridge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.name == "BuildBridge") {
			SceneManager.LoadScene ("BuildBridge");
		}
	}
}
