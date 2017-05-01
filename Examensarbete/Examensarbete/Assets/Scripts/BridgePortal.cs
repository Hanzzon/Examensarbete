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
				MapManager.questions[MapManager.questionIndex].attempt++;
				MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
				mapManager.SelectForDB(BridgeManager.score, BridgeManager.sum, BridgeManager.question, BridgeManager.questionID, 1);
				MapManager.RemoveQuestion (MapManager.questions[MapManager.questionIndex].question);
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
