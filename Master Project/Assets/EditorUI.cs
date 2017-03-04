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
