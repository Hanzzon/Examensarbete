using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static CameraController instance = null;
    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            //print("PLAYER IS NULL");
            //player = GameObject.FindGameObjectWithTag("Player");
            //print(player.ToString());
        }
        //GameObject.DontDestroyOnLoad(gameObject);
        //camera = GetComponent<Transform>();
        offset = transform.position - player.transform.position;
        //CameraPosition();
	}

    private void CameraPosition()
    {
        //print("Camera");
        //GameObject obj = GameObject.Find("MapManager");
        //MapManager script = obj.GetComponent<MapManager>();
        //rb.transform.position = script.SpawnPosition();
        //player.transform.position = script.SpawnPosition();
        //camera.transform.position = script.SpawnPosition();
        print(transform.position);
        if (player.transform.position.y > 100)
        {
            float calc = player.transform.position.y - 87;
            transform.position = new Vector3(player.transform.position.x + offset.x, 75 + calc, -215);
        }
        else
            transform.position = new Vector3(player.transform.position.x + offset.x, 87, -215);
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            if (player.transform.position.y > 100)
            {
                float calc = player.transform.position.y - 87;
                transform.position = new Vector3(player.transform.position.x + offset.x, 75 + calc, -215);
            }
            else
                transform.position = new Vector3(player.transform.position.x + offset.x, 87, -215);
        }
    }
}
