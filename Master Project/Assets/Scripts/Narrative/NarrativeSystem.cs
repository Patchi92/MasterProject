using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeSystem : MonoBehaviour {

    public GameObject playerNormal;
    public GameObject playerVR;

    Transform spawnPoint;
    // Without VR
        
    // With VR


    GameObject UI;
    GameObject DialogSystem;
    GameObject ChoiceSystem;

    void Awake()
    {
        spawnPoint = transform.FindChild("SpawnPoint");

        UI = GameObject.Find("UI");
        DialogSystem = UI.transform.FindChild("Dialog").gameObject;
        ChoiceSystem = UI.transform.FindChild("Choice").gameObject;
    }

    // Use this for initialization
    void Start () {

        PlayerPrefs.SetInt("Artifact", 0);



        if(PlayerPrefs.GetInt("VR") == 0)
        {
            Instantiate(playerNormal, spawnPoint);
        } else
        {
            Instantiate(playerVR, spawnPoint);
        }
       

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Narrative(string info)
    {
        ChoiceSystem.GetComponent<ChoiceSelection>().ResetSystem();
        UI.GetComponent<UiSystem>().LockPlayer();

        if(info == "Quest")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 0);

            if(PlayerPrefs.GetString("Version") == "Simple")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 0);
            }
            
        }

        if (info == "DogOne")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 1);
        }

        if (info == "DogTwo")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 2);
        }

        if (info == "DogThree")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 3);
        }

        if (info == "Sword")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 4);

            if (PlayerPrefs.GetString("Version") == "Simple")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 1);
            }
            
        }

    }

   
}
