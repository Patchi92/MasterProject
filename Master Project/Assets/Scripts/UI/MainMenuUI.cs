using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

    GameObject menu;
    GameObject options;

    void Awake()
    {
        menu = transform.FindChild("Menu").gameObject;
        options = transform.FindChild("Options").gameObject;

    }

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetString("Version", "Simple");
        PlayerPrefs.SetInt("VR", 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }

    public void OptionsBack()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
