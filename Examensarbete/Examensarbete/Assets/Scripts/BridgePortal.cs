using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgePortal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (BridgeManager.sum == BridgeManager.score)
            {
                print("Winner!");
                GameObject obj = GameObject.Find("DialogBoxWinner");
                CanvasGroup cg = obj.GetComponent<CanvasGroup>();
                cg.alpha = 1;
            }
            else
            {
                print("Loser!");
                GameObject obj = GameObject.Find("DialogBoxLoser");
                CanvasGroup cg = obj.GetComponent<CanvasGroup>();
                cg.alpha = 1;
            }
        }
    }
}
