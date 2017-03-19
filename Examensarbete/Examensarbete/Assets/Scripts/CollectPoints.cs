using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectPoints : MonoBehaviour {

	private int collectedItems;
	private int result;
	private string itemsToCollect;
	public Text itemsCollectedText;
	public Text itemsToCollectText;
	// Use this for initialization
	void Start () {
		collectedItems = 0;
		itemsToCollect = "6 * 4";
		result = 24;
		itemsToCollectText.text = "Hämta " + itemsToCollect + " föremål!";

		PlayerHandling.missionIsFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
		itemsCollectedText.text = "Du har hämtat: " + collectedItems;
	}

	void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.name == "scoreObject(Clone)") {
			Destroy (_collision.gameObject);
			collectedItems++;
		}

		if (_collision.gameObject.name == "ExitPortal") {
			if (collectedItems == result) {
				PlayerHandling.completedMissions++;
				PlayerHandling.missionIsFinished = true;
				SceneManager.LoadScene ("Map");
			} 
			else {
				SceneManager.LoadScene ("BuildBridge");
			}
		}
	}
}
