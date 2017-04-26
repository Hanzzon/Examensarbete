using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandling : MonoBehaviour {

    public Text gameOverText;

	// Use this for initialization
	void Start () {
        SetEndText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetEndText()
    {
        gameOverText.text = "Du utforskade " + MapManager.missionsPlayed + " av totalt 10 uppgifter. Bra jobbat!";
    }

    public void PlayAgain()
    {

        ResetPlayerStatus();
        SceneManager.LoadScene("Map");
    }

    public void Exit()
    {

        //ResetPlayerStatus();
        //SceneManager.LoadScene("MainMenu");

        Application.Quit();
    }

    private void ResetPlayerStatus()
    {
        MapManager.missionsPlayed = 0;
        MapManager.instance = null;
    }
}
