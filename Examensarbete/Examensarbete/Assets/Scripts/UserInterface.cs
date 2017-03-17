using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

	public GameObject Info;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerHandling.completedMissions > 0)
		{
			Destroy (Info);
		}
	}

	public void RemoveInfo()
	{
		Destroy (Info);
	}
}
