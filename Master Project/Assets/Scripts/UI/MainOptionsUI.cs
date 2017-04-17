using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainOptionsUI : MonoBehaviour {

 
    GameObject version;
    GameObject VR;

    // Use this for initialization
    void Awake()
    {
        version = transform.FindChild("Version").transform.GetChild(0).gameObject;
        VR = transform.FindChild("VR").gameObject;
    }


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(version.GetComponent<Text>().text == "Simple")
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



        if (PlayerPrefs.GetInt("VR") == 0)
        {
            VR.GetComponent<Image>().color = Color.red;
        } else
        {
            VR.GetComponent<Image>().color = Color.white;
        }

    }

     public void ChangeVR()
    {
        if(PlayerPrefs.GetInt("VR") == 0)
        {
            PlayerPrefs.SetInt("VR", 1);
        } else
        {
            PlayerPrefs.SetInt("VR", 0);
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

}
