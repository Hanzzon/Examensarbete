using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatBossScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject player;
	public Text levelInfo;
	public Text assignmentInfo;

	private int nrOfJumps;
	private int totalJumpsToComplete;

	private bool win;

	// Use this for initialization
	void Start () {

		nrOfJumps = 0;
		totalJumpsToComplete = 10;
		win = false;
	}
	
	// Update is called once per frame
	void Update () {
		levelInfo.text = "Hoppa på fiendens huvud " + totalJumpsToComplete + "!";
		assignmentInfo.text = "Du har hoppat " + nrOfJumps + " gånger!";
	}

	void OnCollisionEnter(Collision _collision)
	{

		if (_collision.gameObject.name == "Boss") {
			print ("Jumped on head");
			nrOfJumps++;
			player.GetComponent<Rigidbody> ().AddForce (new Vector2 (0, 4000));
		}

		if (_collision.gameObject.name == "ExitPortal") {
			PlayerHandling.completedMissions++;
			PlayerHandling.missionIsFinished = true;
			SceneManager.LoadScene ("Map");
		}
	}

	void CheckWinState()
	{
		if (nrOfJumps == totalJumpsToComplete) {

			win = true;
		}
	}
}
