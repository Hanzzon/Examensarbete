using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class BridgeManager : MonoBehaviour {

    public static int score;
    public static int sum;

    public GameObject crates;
    public Text txtInfo;
    public Text txtScore;

    private int objectsToGather;
    private string question;
    
    
    // Use this for initialization
    void Start () {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(-56f, 22.5f, 0f);
        score = 0;
        objectsToGather = 40;
        SpawnCrates();
        ShowInfo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowInfo()
    {
        //string questionDB = MapManager.questionArray[0].question;

        string questionDB = MapManager.PickRandomQuestion();
        //string questionDB = MapManager.questions[1].question;
		//print("QUESTION: " + questionDB + " Amount: " + MapManager.questions.Count);
		
		print ("Removed question. Current amount of questions: " + MapManager.questions.Count);

        sum = int.Parse(MapManager.PickRandomAnswer());
        print(sum);
        string[] splitQuestion = questionDB.Split(new char[0]);
        print(splitQuestion[0]);

        question = splitQuestion[0] + " " + splitQuestion[1] + " " + splitQuestion[2];

        txtInfo.text = "Hämta " + splitQuestion[0] + " " + splitQuestion[1] + " " + splitQuestion[2] + " lådor";
        txtScore.text = "Du har hämtat: " + score.ToString();
    }

    public void AddPlayerScore()
    {
        score++;
        txtScore.text = "Du har hämtat: " + score.ToString();
    }

    void SpawnCrates()
    {
        for (int i = 0; i < objectsToGather; i++)
        {
            Instantiate(crates);
            crates.transform.Translate(10, 0, 0);
            crates.transform.localScale = new Vector3(20, 20, 1);
        }
    }

    public void TryAgain()
    {
        MapManager.questions[0].attempt++;

        MapManager mapManagerDB = GameObject.Find("MapManager").GetComponent<MapManager>();
        mapManagerDB.SelectForDB(score, sum, question);

        SceneManager.LoadScene("BridgeBuilding");    
    }

    public void CancelLevel()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(409f, 98f, 0f);
        MapManager.questions[0].attempt++;

        MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        //mapManager.PlayerPosition(2);
        mapManager.ChangeSign(0, "Loser");

        mapManager.SelectForDB(score, sum, question);

        SceneManager.LoadScene("Map");
    }

    public void Finished()
    {
        Transform gianaMove = GameObject.Find("Giana").GetComponent<Transform>();
        gianaMove.transform.position = new Vector3(409f, 98f, 0f);
        MapManager.questions[0].attempt++;

        MapManager mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        //mapManager.PlayerPosition(2);
        mapManager.DestroyPortal(0);
        mapManager.ChangeSign(0, "Winner");

        mapManager.SelectForDB(score, sum, question);

        //MapManager.questionArray[0] = null;

        SceneManager.LoadScene("Map");
    }
}
