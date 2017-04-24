using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    static MapManager instance = null;

    public static int userID;
    public static string gender;
    public static int playerPos;
    public static float playTimer;

    public static int answer;
    public static int correctAnswer;
    public static string question;

	public static List<QuestionList> questions = new List<QuestionList> ();

    public GameObject player;
    public GameObject[] portals;
    public GameObject[] signs;

    public Vector3[] portalPosition;
    public Vector3[] signPosition;

    private string[] getArray;

    void Awake()
    {
        // Ställ in rätt kön

        // 
        //print(userID);

        
    }

	// Use this for initialization
	void Start ()
    {
        playTimer = 0;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);

            portalPosition = new Vector3[4];
            signPosition = new Vector3[4];
            //questionArray = new QuestionList[3];
            signs = new GameObject[4];
            portals = new GameObject[4];

            //playerPos = 1;
            //PlayerPosition(playerPos);
            PortalSpawn();
            SignSpawn();
            StartCoroutine(GetQuestions());
        }
	}

    void SignSpawn()
    {
        signPosition[0] = new Vector3(409f, 98f, 0f);
        signPosition[1] = new Vector3(1325f, 128f, 0f);
        signPosition[2] = new Vector3(2000f, 127f, 0f);
        signPosition[3] = new Vector3(2815f, 118f, 0f);

        GameObject getPrefab = (GameObject)Resources.Load("Sign", typeof(GameObject));

        for (int i = 0; i < signPosition.Length; i++)
        {
            print(signPosition[i]);
            signs[i] = Instantiate(getPrefab, signPosition[i], Quaternion.identity);
        }
    }

    public void ChangeSign(int input, string message)
    {
        Sign s = signs[input].GetComponent(typeof(Sign)) as Sign;
        s.SetSign(message);
    }

    public void DestroyPortal(int input)
    {
        Destroy(portals[input]);
    }

    void PortalSpawn()
    {
        portalPosition[0] = new Vector3(405f, 160f, 0f);
        portalPosition[1] = new Vector3(1320f, 193f, 0f);
        portalPosition[2] = new Vector3(2000f, 188f, 0f);
        portalPosition[3] = new Vector3(2815f, 178f, 0f);

        GameObject getPrefab = (GameObject)Resources.Load("MissionPortal", typeof(GameObject));

        for (int i = 0; i <portalPosition.Length; i++)
        {
            portals[i] = Instantiate(getPrefab, portalPosition[i], Quaternion.identity);

            switch(i)
            {
                case 0:
                    portals[i].gameObject.tag = "Bridge";
                    break;
                case 1:
                    portals[i].gameObject.tag = "Boss";
                    break;
                default:
                    break;

            }
        }
    }

    void AssignPortalTag(string tagName)
    {

    }

    public void PlayerPosition(int value)
    {
        playerPos = value;
        print(playerPos);
        if (playerPos == 1)
            player.transform.position = new Vector3(-53f, 21f, 0f);
        else if (playerPos == 2)
            player.transform.position = new Vector3(410f, 100f, 0f);
    }

    public Vector3 SpawnPosition()
    {
        return player.transform.position;
    }

    public void SelectForDB(int inAnswer, int inCorrectAnswer, string inQuestion)
    {
        answer = inAnswer;
        correctAnswer = inCorrectAnswer;
        question = inQuestion;

        StartCoroutine(SendToDB());
    }

    void Update()
    {
        playTimer += Time.deltaTime;
    }

    IEnumerator GetQuestions()
    {
        string questionsURL = "http://examen.sytes.net/scripts/questions.php";

        WWW www = new WWW(questionsURL);
        yield return www;
        string result = www.text;

        if (result != null)
        {
            getArray = result.Split(';');
        }

        for (int i = 0; i < getArray.Length - 1; i++)
        {
            int idDB = int.Parse(GetDataValue(getArray[i], "ID:"));
            string questionDB = GetDataValue(getArray[i], "Question:");
            string answerDB = GetDataValue(getArray[i], "Answer:");

			questions.Add(new QuestionList(idDB, questionDB, answerDB, 0));
        }
    }

	public static string PickRandomQuestion()
	{
		int questionIndex = Random.Range (0, questions.Count);
		print ("QUESTIONINDEX: " + questionIndex);

		for (int i = 0; i < questions.Count; i++) 
		{
			return questions [questionIndex].question;
		}

		return null;
	}

	public static void RemoveQuestion(string _input)
	{
		for (int i = 0; i < questions.Count; i++) {
			if (questions[i].question == _input) {
				questions.RemoveAt (i);
			}
		}
	}

    IEnumerator SendToDB()
    {
        int timer = (int)playTimer;
        string attemptURL = "http://examen.sytes.net/scripts/attempt.php";

        WWWForm form = new WWWForm();
        form.AddField("useridPost", userID);
        form.AddField("timerPost", timer);
        form.AddField("attemptPost", questions[0].attempt);
        form.AddField("answerPost", answer);
        form.AddField("correctanswerPost", correctAnswer);
        form.AddField("questionPost", question);

        WWW www = new WWW(attemptURL, form);

        yield return www;
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
            value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
