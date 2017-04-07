using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeSystem : MonoBehaviour {

    Scene scene;

  
    

    GameObject player;

    Vector3 spawnPoint;

    // Without VR
    public GameObject playerNormal;

    // With VR
    public GameObject playerVR;


    GameObject UI;
    GameObject DialogSystem;
    GameObject ChoiceSystem;

    string currentNarrative;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();

        spawnPoint = transform.FindChild("SpawnPoint").position;

        UI = GameObject.Find("UI");
        DialogSystem = UI.transform.FindChild("Dialog").gameObject;
        ChoiceSystem = UI.transform.FindChild("Choice").gameObject;
    }

    // Use this for initialization
    void Start () {

        PlayerPrefs.SetInt("Artifact", 0);



        if(PlayerPrefs.GetInt("VR") == 0)
        {
            player = Instantiate(playerNormal, spawnPoint, Quaternion.identity);
        } else
        {
            player = Instantiate(playerVR, spawnPoint, Quaternion.identity);
        }
       
        if(scene.name == "ChapterOne")
        {
            PlayerPrefs.SetString("PlayerClass", "Nothing");
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Narrative(string info)
    {
        currentNarrative = info;

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

        if (info == "Warrior")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 4);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 1);
            } 
            
        }

        if (info == "Mage")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 5);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 2);
            }

        }

        if (info == "Assassin")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 6);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 3);
            }

        }

    }

    public void NarrativeFeedback(int choice)
    {
        if (choice == 0)
        {
            if (currentNarrative == "Warrior")
            {
                PlayerPrefs.SetString("PlayerClass", "Warrior");
                player.GetComponent<PlayerClass>().enabled = true;
            }

            if (currentNarrative == "Mage")
            {
                PlayerPrefs.SetString("PlayerClass", "Mage");
                player.GetComponent<PlayerClass>().enabled = true;
            }

            if (currentNarrative == "Assassin")
            {
                PlayerPrefs.SetString("PlayerClass", "Assassin");
                player.GetComponent<PlayerClass>().enabled = true;
            }
        }

        if (choice == 1)
        {
            if (currentNarrative == "Warrior")
            {
                PlayerPrefs.SetString("PlayerClass", "Warrior");
                player.GetComponent<PlayerClass>().enabled = true;
            }

            if (currentNarrative == "Mage")
            {
                PlayerPrefs.SetString("PlayerClass", "Mage");
                player.GetComponent<PlayerClass>().enabled = true;
            }

            if (currentNarrative == "Assassin")
            {
                PlayerPrefs.SetString("PlayerClass", "Assassin");
                player.GetComponent<PlayerClass>().enabled = true;
            }
        }

        if (choice == 2)
        {
           
        }

        if (choice == 3)
        {

        }

        if (choice == 4)
        {

        }

    }
   
}
