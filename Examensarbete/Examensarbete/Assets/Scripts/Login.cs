using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public GameObject user;
    public GameObject pass;

	public Text username;
	public Text password;

    private string userid;
    private string userpassword;
    private bool check;

    void Awake()
    {
        string idPrefs = PlayerPrefs.GetString("userid");
        string passPrefs = PlayerPrefs.GetString("password");

		if (idPrefs.Length > 2 && passPrefs.Length > 2)
        {
            user.GetComponent<Text>().text = idPrefs.ToString();
            pass.GetComponent<Text>().text = passPrefs.ToString();
        }
    }

	public void LoginUser()
	{
		if (userid != "" && userpassword != "")
        {
            print("STARTED");
            print("ID: " + userid);
            print("PASS: " + userpassword);
            StartCoroutine(LoginUser(userid, userpassword));
            
		}
		else
			print ("Fail!");
	}

    IEnumerator LoginUser(string name, string pass)
    {
        string loginUserURL = "http://examen.sytes.net/scripts/login.php";

        print("ID: " + name);
        print("PASS: " + pass);

        WWWForm form = new WWWForm();
        form.AddField("useridPost", int.Parse(name));
        form.AddField("passwordPost", int.Parse(pass));

        WWW www = new WWW(loginUserURL, form);

        yield return www;

        string result = www.text;
        print("RESULT: " + result);

        if (result.Contains("User not found"))
        {
            print(result);
            //Result.text = "User not Found!";
        }
        else if (result.Contains("Wrong password"))
        {
            print(result);
            //Result.text = "Wrong Password!";
        }
        else
        {
            if (check)
            {
                print("Save userinfo");
				PlayerPrefs.SetString("userid", name);
                PlayerPrefs.SetString("password", pass);
            }
            MapManager.gender = "girl";
            MapManager.userID = int.Parse(result);
            SceneManager.LoadScene("Map");
        }
    }

    void Update()
    {
        userid = user.GetComponent<Text>().text;
        userpassword = pass.GetComponent<Text>().text;
    }

    public void SaveUserLogin(bool info)
    {
        check = info;
    }
}
