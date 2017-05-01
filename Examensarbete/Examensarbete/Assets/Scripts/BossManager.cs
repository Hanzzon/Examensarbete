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
	public static string question;
	public static int questionID;

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
		questionID = MapManager.questions [MapManager.questionIndex].id;

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
		MapManager.questions[MapManager.questionIndex].attempt++;

        MapManager mapManagerDB = GameObject.Find("MapManager").GetComponent<MapManager>();
		mapManagerDB.SelectForDB(score, sum, question, questionID, 0);

        SceneManager.LoadScene("BossBattle");
    }

    public void CancelLevel()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(1325f, 128f, 0f);
		MapManager.questions[MapManager.questionIndex].attempt++;
        MapManager.missionsPlayed--;

        MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

        for (int i = 0; i < MapManager.signPosition.Length; i++)
        {
            mapManager.ChangeSign(MapManager.missionsPlayed, "Loser");
        }

        print("Missions played: " + MapManager.missionsPlayed);
        //mapManager.ChangeSign(1, "Loser");

		mapManager.SelectForDB(score, sum, question, questionID, 0);

        SceneManager.LoadScene("Map");
    }

    public void Finished()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(1325f, 128f, 0f);
		//MapManager.questions[MapManager.questionIndex].attempt++;

        //MapManager.missionsPlayed++;

        MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

        for (int i = 0; i < MapManager.signPosition.Length; i++)
        {
            mapManager.DestroyPortal(MapManager.missionsPlayed - 1);
            mapManager.ChangeSign(MapManager.missionsPlayed - 1, "Winner");
        }

        //mapManager.DestroyPortal(1);
        //mapManager.ChangeSign(1, "Winner");


        print("Missions played: " + MapManager.missionsPlayed);

		//mapManager.SelectForDB(score, sum, question, questionID, 1);
		MapManager.RemoveQuestion (MapManager.questions[MapManager.questionIndex].question);

        SceneManager.LoadScene("Map");
    }
}
