using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	public Text username;
	public Text password;

	public void LoginUser()
	{
		if (username.text.Contains ("100") && password.text.Contains ("123")) {
			print ("Success!");
			SceneManager.LoadScene ("Map");
		}
		else
			print ("Fail!");
	}
}
