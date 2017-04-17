using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour {

    static Sign instance = null;

    public Sprite[] progress;

    void Start()
    {
        //if (instance != null)
        //{
            
        //}
        //else
        //{
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        //}
    }

    public void SetSign(string message)
    {
        if (message.Contains("Loser"))
        {
            this.GetComponent<SpriteRenderer>().sprite = progress[0];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = progress[1];
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {

        }
    }
}
