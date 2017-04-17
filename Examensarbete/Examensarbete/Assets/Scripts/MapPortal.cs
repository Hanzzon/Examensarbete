using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    static MapPortal instance = null;

	// Use this for initialization
	void Start ()
    {
        //if (instance != null)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        //}
    }
}
