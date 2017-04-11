using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //transform.position = player.transform.position + offset;

        // Camera follows the player with specified offset position
        if (player.transform.position.y > 100)
        {
            float calc = player.transform.position.y - 87;
            transform.position = new Vector3(player.transform.position.x + offset.x, 75 + calc, offset.z);
        }
        else
            transform.position = new Vector3(player.transform.position.x + offset.x, 87, offset.z); 
    }
}
