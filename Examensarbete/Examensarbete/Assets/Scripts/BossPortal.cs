using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPortal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (BossManager.sum == BossManager.score)
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
