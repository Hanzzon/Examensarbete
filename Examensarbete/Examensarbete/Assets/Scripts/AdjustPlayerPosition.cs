using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPlayerPosition : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        SetPlayerPosition();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetPlayerPosition()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i + 1 == MapManager.missionsPlayed)
            {
                player.transform.position = MapManager.signPosition[i];
                print("Player transformed");
            }

        }
    }
}
