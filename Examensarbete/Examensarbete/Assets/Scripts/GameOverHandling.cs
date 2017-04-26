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
        gameOverText.text = "Bra jobbat! Du utforskade " + MapManager.missionsPlayed + " av totalt 10 uppgifter. Tack för din medverkan!";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Map");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
