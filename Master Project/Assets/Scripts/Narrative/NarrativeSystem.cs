﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeSystem : MonoBehaviour {

    Scene scene;

  
    

    GameObject player;

    Vector3 spawnPoint;

    //GameObject systemLookingAt;

    // Without VR
    public GameObject playerNormal;

    // With VR
    public GameObject playerVR;


    GameObject UI;
    GameObject DialogSystem;
    GameObject ChoiceSystem;

    // Chapters
    public GameObject daySystem;
    public GameObject ChapterOne;
    public GameObject ChapterTwo;
    public GameObject ChapterThree;

    string currentNarrative;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();

        spawnPoint = transform.FindChild("SpawnPoint Chapter One").position;

        UI = GameObject.Find("UI");
        DialogSystem = UI.transform.FindChild("Dialog").gameObject;
        ChoiceSystem = UI.transform.FindChild("Choice").gameObject;
    }

    // Use this for initialization
    void Start () {

        if(Application.isEditor == false)
        {
            PlayerPrefs.DeleteAll();
        }

        Debug.Log(PlayerPrefs.GetString("Version"));

        // Player Behavior

        PlayerPrefs.SetInt("Destruction", 0);
        PlayerPrefs.SetInt("Excitement", 0);
        PlayerPrefs.SetInt("Challenge", 3);
        PlayerPrefs.SetInt("Strategy", 3);
        PlayerPrefs.SetInt("Completion", 0);
        PlayerPrefs.SetInt("Power", 3);
        PlayerPrefs.SetInt("Fantasy", 3);
        PlayerPrefs.SetInt("Story", 3);
        PlayerPrefs.SetInt("Design", 3);
        PlayerPrefs.SetInt("Discovery", 3);

        PlayerPrefs.SetInt("Community", 3);
        PlayerPrefs.SetInt("Competition", 3);


        // Player Tracking

        PlayerPrefs.SetString("PlayerClass", "Nothing");
        PlayerPrefs.SetString("PlayerType", "Nothing");
        PlayerPrefs.SetInt("HeroPoints", 0);
        PlayerPrefs.SetInt("KillerPoints", 0);
        PlayerPrefs.SetInt("PacifistPoints", 0);
        PlayerPrefs.SetInt("NPCsKilled", 0);


        if (PlayerPrefs.GetInt("VR") == 0)
        {
            player = Instantiate(playerNormal, spawnPoint, Quaternion.identity);
        } else
        {
            player = Instantiate(playerVR, spawnPoint, Quaternion.identity);
        }
       
        if(scene.name == "Game")
        {
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {


        if(PlayerPrefs.GetInt("KillerPoints") == 0 && PlayerPrefs.GetInt("HeroPoints") == 0)
        {
            PlayerPrefs.SetString("PlayerType", "Pacifist");
        } else if (PlayerPrefs.GetInt("NPCsKilled") == 0 && PlayerPrefs.GetInt("HeroPoints") > PlayerPrefs.GetInt("KillerPoints"))
        {
            PlayerPrefs.SetString("PlayerType", "Hero");
        } else
        {
            PlayerPrefs.SetString("PlayerType", "Killer");
        }

	}

    public void ChapterSelect(int info)
    {
        if(info == 2)
        {
            daySystem.GetComponent<DaySystem>().StartCoroutine("DayAndNightSystem");
            ChapterOne.SetActive(false);
            ChapterTwo.SetActive(true);
            player.SetActive(true);
        }

        if (info == 3)
        {
            RenderSettings.ambientIntensity = 0.3f;
            ChapterTwo.SetActive(false);
            ChapterThree.SetActive(true);
            player.SetActive(true);
        }

    }


    public void Narrative(string info)
    {
        currentNarrative = info;

        ChoiceSystem.GetComponent<ChoiceSelection>().ResetSystem();
        UI.GetComponent<UiSystem>().LockPlayer();

        if(info == "WitchIntro_Simple")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 0);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 0);
        }

        if (info == "WitchIntro_Complex")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 1);
        }

        if (info == "Cave")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 10);
        }

        if (info == "PacifistIntro")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 2);
        }

        if (info == "HeroIntro")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 3);
        }

        if (info == "KillerIntro")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 4);
        }

        if (info == "Warrior")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 5);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 1);
            } 
            
        }

        if (info == "Mage")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 6);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 2);
            }

        }

        if (info == "Assassin")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 7);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 3);
            }

        }


        if (info == "WitchEnd_Simple")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 8);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 4);
        }

        if (info == "WitchEnd_Complex")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 9);
        }


    }

    public void NarrativeFeedback(int choice)
    {

        Debug.Log(PlayerPrefs.GetString("PlayerType"));

        if (currentNarrative == "WitchIntro_Simple")
        {
            if (choice == 1)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));
            }

            if (choice == 2)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));
            }

            if (choice == 3)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") - 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));
            }

        }

        if (currentNarrative == "Warrior")
        {
            if (choice == 0)
            {
                PlayerPrefs.SetString("PlayerClass", "Warrior");
                player.GetComponent<PlayerClass>().enabled = true;
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Simple";
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Complex";

                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").transform.FindChild("SpeakArea").gameObject.SetActive(true);
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").transform.FindChild("SpeakArea").gameObject.SetActive(true);

                GameObject.Find("Warrior_Weapon").SetActive(false);
                GameObject.Find("Mage_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
                GameObject.Find("Assassin_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);

            }

            if (choice == 1)
            {
                PlayerPrefs.SetString("PlayerClass", "Warrior");
                player.GetComponent<PlayerClass>().enabled = true;
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Simple";
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Complex";

                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").transform.FindChild("SpeakArea").gameObject.SetActive(true);
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").transform.FindChild("SpeakArea").gameObject.SetActive(true);

                GameObject.Find("Warrior_Weapon").SetActive(false);
                GameObject.Find("Mage_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
                GameObject.Find("Assassin_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
            }

        }

        if (currentNarrative == "Mage")
        {
            if (choice == 0)
            {
                PlayerPrefs.SetString("PlayerClass", "Mage");
                player.GetComponent<PlayerClass>().enabled = true;
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Simple";
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Complex";

                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").transform.FindChild("SpeakArea").gameObject.SetActive(true);
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").transform.FindChild("SpeakArea").gameObject.SetActive(true);

                GameObject.Find("Mage_Weapon").SetActive(false);
                GameObject.Find("Warrior_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
                GameObject.Find("Assassin_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
            }

            if (choice == 1)
            {
                PlayerPrefs.SetString("PlayerClass", "Mage");
                player.GetComponent<PlayerClass>().enabled = true;
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Simple";
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Complex";

                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").transform.FindChild("SpeakArea").gameObject.SetActive(true);
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").transform.FindChild("SpeakArea").gameObject.SetActive(true);

                GameObject.Find("Mage_Weapon").SetActive(false);
                GameObject.Find("Warrior_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
                GameObject.Find("Assassin_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
            }

        }

        if (currentNarrative == "Assassin")
        {
            if (choice == 0)
            {
                PlayerPrefs.SetString("PlayerClass", "Assassin");
                player.GetComponent<PlayerClass>().enabled = true;
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Simple";
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Complex";

                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").transform.FindChild("SpeakArea").gameObject.SetActive(true);
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").transform.FindChild("SpeakArea").gameObject.SetActive(true);

                GameObject.Find("Assassin_Weapon").SetActive(false);
                GameObject.Find("Warrior_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
                GameObject.Find("Mage_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
            }

            if (choice == 1)
            {
                PlayerPrefs.SetString("PlayerClass", "Assassin");
                player.GetComponent<PlayerClass>().enabled = true;
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Simple";
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").gameObject.GetComponent<NPC>().dialog = "WitchEnd_Complex";

                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Simple").transform.FindChild("SpeakArea").gameObject.SetActive(true);
                GameObject.Find("NPC_ChapterOne").transform.FindChild("Witch_Complex").transform.FindChild("SpeakArea").gameObject.SetActive(true);

                GameObject.Find("Assassin_Weapon").SetActive(false);
                GameObject.Find("Warrior_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
                GameObject.Find("Mage_Weapon").transform.FindChild("SpeakArea").gameObject.SetActive(false);
            }

        }


        if (currentNarrative == "WitchEnd_Simple")
        {
            if (choice == 1)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));
            }

            if (choice == 2)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));
            }

            if (choice == 3)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") - 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));

                GameObject.Find("Witch_Simple").GetComponent<EnemyRanged>().enabled = true;
            }
            
            gameObject.transform.FindChild("EndChapterOne").gameObject.SetActive(true);
        }


    }
   
}
