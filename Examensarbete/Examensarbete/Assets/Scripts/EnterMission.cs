using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMission : MonoBehaviour {

	private int levelIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D _collision)
	{
		levelIndex = Random.Range (1, 3);
		if (_collision.gameObject.name == "MissionPortal") {
			if (levelIndex == 1) {
				SceneManager.LoadScene ("BuildBridge");
				print(levelIndex);
			}
			else if(levelIndex == 2)
			{
				SceneManager.LoadScene ("MissionDefeatEnemy");
			}
		}
	}
}
