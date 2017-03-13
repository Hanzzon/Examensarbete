using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridgeScript : MonoBehaviour {

	private int objectsToGather;
	public GameObject objectToCreate;

	// Use this for initialization
	void Start () {
		objectsToGather = 50;
		CreateObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CreateObjects()
	{
		System.Random random = new System.Random ();
		int height = 100;

		for (int i = 0; i < objectsToGather; i++) {
			

			Instantiate (objectToCreate);
			objectToCreate.transform.Translate (20, 0, 0);
			objectToCreate.transform.localScale = new Vector3 (10, 10, 10);
		}
	}

}
