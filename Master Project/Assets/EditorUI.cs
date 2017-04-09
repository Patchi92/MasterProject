using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorUI : MonoBehaviour {

    GameObject version;

    void Awake()
    {
        version = transform.FindChild("Version").transform.GetChild(0).gameObject;
    }


    // Use this for initialization
    void Start () {
		if(Application.isEditor == false)
        {
            gameObject.SetActive(false);
        } 

        if (PlayerPrefs.GetString("Version") == "Simple")
        {
            version.GetComponent<Text>().text = "Simple";
        }

        if (PlayerPrefs.GetString("Version") == "Complex")
        {
            version.GetComponent<Text>().text = "Complex";
        }

        if (PlayerPrefs.GetString("Version") == "Mixed")
        {
            version.GetComponent<Text>().text = "Mixed";
        }

    }
	
	// Update is called once per frame
	void Update () {

        // Enable Mouse

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        if (Input.GetKey(KeyCode.L))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKey(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Version", version.GetComponent<Text>().text);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 10f;
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Time.timeScale = 1f;
        }


        // Change Version

        if (version.GetComponent<Text>().text == "Simple")
        {
            PlayerPrefs.SetString("Version", "Simple");
        }

        if (version.GetComponent<Text>().text == "Complex")
        {
            PlayerPrefs.SetString("Version", "Complex");
        }

        if (version.GetComponent<Text>().text == "Mixed")
        {
            PlayerPrefs.SetString("Version", "Mixed");
        }

    }
}
