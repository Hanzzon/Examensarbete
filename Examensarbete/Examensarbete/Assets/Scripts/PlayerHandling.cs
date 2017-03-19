using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandling : MonoBehaviour {

	public GameObject player;
	public static int completedMissions = 0;
	public static bool missionIsFinished = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckCompletedMissions ();
	}

	void CheckCompletedMissions()
	{
		if (missionIsFinished == true) {
			print ("MISSION IS FINISHED!");
			if (completedMissions == 1) {
				player.transform.position = new Vector3 (400, 30, 100);
				missionIsFinished = false;
				print("PLAYER IS TRANSFORMED TO FIRST POINT!");
			}
			else if(completedMissions == 2)
			{
				player.transform.position = new Vector3 (1250, 30, 100);
				missionIsFinished = false;
				print ("PLAYER IS TRANSFORMED TO SECOND POINT");
			}
		}
	}
}
