using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EnterBuildBridge : MonoBehaviour {

	private int levelIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		levelIndex = Random.Range (1, 3);
	}

	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.name == "BuildBridge") {
			if (levelIndex == 1) {
				SceneManager.LoadScene ("BuildBridge");
			}
			else if(levelIndex == 2)
			{
				SceneManager.LoadScene ("MissionDefeatEnemy");
			}
		}
	}
}
