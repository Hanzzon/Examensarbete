using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance = null;

    public static int userID;
    public static string gender;
    public static int playerPos;
    public static float playTimer;

    public static int answer;
    public static int correctAnswer;
    public static string question;

    public static int roundsPlayed;

	public static List<QuestionList> questions = new List<QuestionList> ();

    public GameObject player;
    public GameObject[] portals;
    public GameObject[] signs;

    public Vector3[] portalPosition;
    public static Vector3[] signPosition;

    private string[] getArray;

    public static int missionsPlayed = 0;
    public static int questionIndex;

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

            portalPosition = new Vector3[10];
            signPosition = new Vector3[10];
            //questionArray = new QuestionList[3];
            signs = new GameObject[10];
            portals = new GameObject[10];

            //playerPos = 1;
            //PlayerPosition(playerPos);
            

            PortalSpawn();
            SignSpawn();

            StartCoroutine(GetFromDB());
            StartCoroutine(SendRoundToDB());
            StartCoroutine(GetQuestions());

            PlayerPosition();
        }
	}

    void SignSpawn()
    {
        signPosition[0] = new Vector3(409f, 98f, 0f);
        signPosition[1] = new Vector3(830f, 20f, 0f);
        signPosition[2] = new Vector3(1325f, 128f, 0f);
        signPosition[3] = new Vector3(2000f, 127f, 0f);
        signPosition[4] = new Vector3(2815f, 118f, 0f);

        signPosition[5] = new Vector3(3300f, 125f, 0f);
        signPosition[6] = new Vector3(3870f, 100f, 0f);
        signPosition[7] = new Vector3(4120f, 127f, 0f);
        signPosition[8] = new Vector3(4540f, 55f, 0f);
        signPosition[9] = new Vector3(4960f, 55f, 0f);
        

        GameObject getPrefab = (GameObject)Resources.Load("Sign", typeof(GameObject));

        for (int i = 0; i < signPosition.Length; i++)
        {
            //print(signPosition[i]);
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
        portalPosition[1] = new Vector3(830f, 70f, 0f);
        portalPosition[2] = new Vector3(1320f, 180f, 0f);
        portalPosition[3] = new Vector3(2000f, 188f, 0f);
        portalPosition[4] = new Vector3(2815f, 178f, 0f);
        portalPosition[5] = new Vector3(3300f, 170f, 0f);
        portalPosition[6] = new Vector3(3870f, 150f, 0f);
        portalPosition[7] = new Vector3(4120f, 180f, 0f);
        portalPosition[8] = new Vector3(4500f, 100f, 0f);
        portalPosition[9] = new Vector3(4950f, 100f, 0f);

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

                case 2:
                    portals[i].gameObject.tag = "Bridge";
                    break;
                case 3:
                    portals[i].gameObject.tag = "Boss";
                    break;
                case 4:
                    portals[i].gameObject.tag = "Bridge";
                    break;
                case 5:
                    portals[i].gameObject.tag = "Boss";
                    break;
                case 6:
                    portals[i].gameObject.tag = "Bridge";
                    break;
                case 7:
                    portals[i].gameObject.tag = "Boss";
                    break;
                case 8:
                    portals[i].gameObject.tag = "Bridge";
                    break;
                case 9:
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

    public void PlayerPosition()
    {
        //playerPos = value;
        //print(playerPos);
        //if (playerPos == 1)
        //    player.transform.position = new Vector3(-53f, 21f, 0f);
        //else if (playerPos == 2)
        //    player.transform.position = new Vector3(410f, 100f, 0f);

        //print("Player transformed           " + "played missions = " + missionsPlayed);

        for (int i = 0; i < signPosition.Length; i++)
        {
            if (missionsPlayed == i)
            {
                //player.transform.position = signPosition[i + 1];
                player.transform.position = new Vector3(2815f, 178f, 0f);

                //print("Played transformed to: " + signPosition[i + 1].ToString());
            }
        }
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

        questionIndex = Random.Range(0, questions.Count);
        //print ("QUESTIONINDEX: " + questionIndex);

        for (int i = 0; i < questions.Count; i++) 
		{
            print("QUESTION: " + questions[questionIndex].question);
            return questions [questionIndex].question;
            
        }

		return null;
	}

    public static string PickRandomAnswer()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            print("Answer: " + questions[questionIndex].answer);
            return questions[questionIndex].answer;
            
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
        form.AddField("playedPost", roundsPlayed);
        form.AddField("correctanswerPost", correctAnswer);
        form.AddField("questionPost", question);

        WWW www = new WWW(attemptURL, form);

        yield return www;
    }

    IEnumerator SendRoundToDB()
    {
        int timer = (int)playTimer;
        string attemptURL = "http://examen.sytes.net/scripts/setPlayed.php";

        WWWForm form = new WWWForm();
        form.AddField("useridPost", userID);
        form.AddField("playedPost", roundsPlayed);

        WWW www = new WWW(attemptURL, form);

        yield return www;
    }

    IEnumerator GetFromDB()
    {
        int timer = (int)playTimer;
        string attemptURL = "http://examen.sytes.net/scripts/getPlayed.php";

        WWWForm form = new WWWForm();
        form.AddField("useridPost", userID);

        WWW www = new WWW(attemptURL, form);

        yield return www;

        roundsPlayed = int.Parse(www.text) + 1;
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
            value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
