using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public static int score;
    public static int sum;

    public Text txtInfo;
    public Text txtScore;

    private int objectsToGather;
    private string question;

    // Use this for initialization
    void Start ()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(-15f, 103f, 0f);
        score = 0;
        ShowInfo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowInfo()
    {
        string questionDB = MapManager.PickRandomQuestion();

        print("Removed question. Current amount of questions: " + MapManager.questions.Count);

        sum = int.Parse(MapManager.PickRandomAnswer());
        print(sum);
        string[] splitQuestion = questionDB.Split(new char[0]);
        print(splitQuestion[0]);

        question = splitQuestion[0] + " " + splitQuestion[1] + " " + splitQuestion[2];

        txtInfo.text = "Hoppa " + splitQuestion[0] + " " + splitQuestion[1] + " " + splitQuestion[2] + " på huvudet";
        txtScore.text = "Du har hoppat: " + score.ToString();
    }

    public void AddPlayerScore()
    {
        score++;
        txtScore.text = "Du har hoppat: " + score.ToString();
    }

    public void TryAgain()
    {
        MapManager.questions[1].attempt++;

        MapManager mapManagerDB = GameObject.Find("MapManager").GetComponent<MapManager>();
        mapManagerDB.SelectForDB(score, sum, question);

        SceneManager.LoadScene("BridgeBuilding");
    }

    public void CancelLevel()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(1325f, 128f, 0f);
        MapManager.questions[1].attempt++;

        MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        mapManager.ChangeSign(1, "Loser");

        mapManager.SelectForDB(score, sum, question);

        SceneManager.LoadScene("Map");
    }

    public void Finished()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(1325f, 128f, 0f);
        MapManager.questions[1].attempt++;

        MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        mapManager.DestroyPortal(1);
        mapManager.ChangeSign(1, "Winner");

        mapManager.SelectForDB(score, sum, question);

        SceneManager.LoadScene("Map");
    }
}
