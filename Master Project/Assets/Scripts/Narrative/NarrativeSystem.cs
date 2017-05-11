using System.Collections;
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

    public GameObject questionnaire;

    // Chapters
    public GameObject daySystem;
    public GameObject ChapterOne;
    public GameObject ChapterTwo;
    public GameObject ChapterThree;

    string currentNarrative;
    public bool unlockPlayerType; 

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

        ChapterOne.SetActive(true);
        ChapterTwo.SetActive(false);
        ChapterThree.SetActive(false);

        if(Application.isEditor == false)
        {
            PlayerPrefs.DeleteAll();
        }

        Debug.Log(PlayerPrefs.GetString("Version"));

        // Player Behavior

        PlayerPrefs.SetInt("Destruction", 0);
        PlayerPrefs.SetInt("Excitement", 0);
        PlayerPrefs.SetInt("Challenge", 0);
        PlayerPrefs.SetInt("Strategy", 0);
        PlayerPrefs.SetInt("Completion", 0);
        PlayerPrefs.SetInt("Power", 0);
        PlayerPrefs.SetInt("Fantasy", 0);

        if(PlayerPrefs.GetString("Version") == "Complex")
        {
            PlayerPrefs.SetInt("Story", 5);
        } else
        {
            PlayerPrefs.SetInt("Story", 3);
        }
        

        PlayerPrefs.SetInt("Design", 0);
        PlayerPrefs.SetInt("Discovery", 0);

        //PlayerPrefs.SetInt("Community", 3);
        //PlayerPrefs.SetInt("Competition", 3);


        // Player Tracking

        PlayerPrefs.SetString("PlayerClass", "Nothing");
        PlayerPrefs.SetString("PlayerType", "Nothing");
        PlayerPrefs.SetInt("HeroPoints", 0);
        PlayerPrefs.SetInt("KillerPoints", 0);
        PlayerPrefs.SetInt("PacifistPoints", 0);
        PlayerPrefs.SetInt("NPCsKilled", 0);
        PlayerPrefs.SetInt("Quests", 0);

        PlayerPrefs.SetInt("CurrentChapter", 1);
        PlayerPrefs.SetInt("PlayerGold", 0);
        PlayerPrefs.SetInt("PlayerHP", 0);
        PlayerPrefs.SetInt("PlayerDeath", 0);
        PlayerPrefs.SetInt("PlayerDamageTaken", 0);
        PlayerPrefs.SetInt("PlayerLevel", 0);
        PlayerPrefs.SetInt("PlayerClassChanges", 0);
        PlayerPrefs.SetInt("PlayerDiscoveryPoints", 0);




        questionnaire.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

        if (unlockPlayerType)
        {
            if (PlayerPrefs.GetInt("KillerPoints") == 0 && PlayerPrefs.GetInt("HeroPoints") == 0)
            {
                PlayerPrefs.SetString("PlayerType", "Pacifist");
            }
            else if (PlayerPrefs.GetInt("NPCsKilled") == 0 && PlayerPrefs.GetInt("HeroPoints") > PlayerPrefs.GetInt("KillerPoints"))
            {
                PlayerPrefs.SetString("PlayerType", "Hero");
            }
            else
            {
                PlayerPrefs.SetString("PlayerType", "Killer");
            }
        }

	}

    public void GameEnd()
    {

        // Destruction

        PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("NPCsKilled"));

        if(PlayerPrefs.GetInt("Destruction") > 5) 
        {
            PlayerPrefs.SetInt("Destruction", 5);
        }


        // Excitement

        PlayerPrefs.SetInt("Excitement", PlayerPrefs.GetInt("HeroPoints"));

        if (PlayerPrefs.GetInt("Excitement") > 5)
        {
            PlayerPrefs.SetInt("Excitement", 5);
        }


        // Challenge + Strategy

        if (PlayerPrefs.GetInt("PlayerDamageTaken") > 50)
        {
            PlayerPrefs.SetInt("Challenge", 1);
            PlayerPrefs.SetInt("Strategy", 1);
        }

        if (PlayerPrefs.GetInt("PlayerDamageTaken") < 50)
        {
            PlayerPrefs.SetInt("Challenge", 2);
            PlayerPrefs.SetInt("Strategy", 2);
        }

        if (PlayerPrefs.GetInt("PlayerDamageTaken") < 40)
        {
            PlayerPrefs.SetInt("Challenge", 3);
            PlayerPrefs.SetInt("Strategy", 3);
        }

        if (PlayerPrefs.GetInt("PlayerDamageTaken") < 30)
        {
            PlayerPrefs.SetInt("Challenge", 4);
            PlayerPrefs.SetInt("Strategy", 4);
        }

        if (PlayerPrefs.GetInt("PlayerDamageTaken") < 20)
        {
            PlayerPrefs.SetInt("Challenge", 5);
            PlayerPrefs.SetInt("Strategy", 5);
        }

        PlayerPrefs.SetInt("Challenge", PlayerPrefs.GetInt("Challenge") - PlayerPrefs.GetInt("PlayerDeath"));

        // Completion

        if (PlayerPrefs.GetInt("PlayerGold") < 100)
        {
            PlayerPrefs.SetInt("Completion", PlayerPrefs.GetInt("Quests") + 1);
        }

        if (PlayerPrefs.GetInt("PlayerGold") < 200)
        {
            PlayerPrefs.SetInt("Completion", PlayerPrefs.GetInt("Quests") + 2);
        }

        if (PlayerPrefs.GetInt("PlayerGold") < 300)
        {
            PlayerPrefs.SetInt("Completion", PlayerPrefs.GetInt("Quests") + 3);
        }


        // Power

        if (PlayerPrefs.GetInt("PlayerLevel") >= 10)
        {
            PlayerPrefs.SetInt("Power", 5);
        }
        if (PlayerPrefs.GetInt("PlayerLevel") >= 8 && PlayerPrefs.GetInt("PlayerLevel") < 10)
        {
            PlayerPrefs.SetInt("Power", 4);
        }

        if (PlayerPrefs.GetInt("PlayerLevel") >= 6 && PlayerPrefs.GetInt("PlayerLevel") < 8)
        {
            PlayerPrefs.SetInt("Power", 3);
        }

        if (PlayerPrefs.GetInt("PlayerLevel") >= 4 && PlayerPrefs.GetInt("PlayerLevel") < 6)
        {
            PlayerPrefs.SetInt("Power", 2);
        }

        if (PlayerPrefs.GetInt("PlayerLevel") >= 2 && PlayerPrefs.GetInt("PlayerLevel") < 4)
        {
            PlayerPrefs.SetInt("Power", 1);
        }




        // Design

        PlayerPrefs.SetInt("Design", PlayerPrefs.GetInt("PlayerClassChanges") - 1);


        // Discovery

        PlayerPrefs.SetInt("Discovery", PlayerPrefs.GetInt("PlayerDiscoveryPoints"));


        questionnaire.SetActive(true);


    }


    public void ChapterSelect(int info)
    {

        if(info == 1)
        {
            if (PlayerPrefs.GetInt("VR") == 0)
            {
                player = Instantiate(playerNormal, spawnPoint, Quaternion.identity);
            }
            else
            {
                player = Instantiate(playerVR, spawnPoint, Quaternion.identity);
            }

            if (scene.name == "Game")
            {
                player.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }

        if(info == 2)
        {
            Cursor.visible = false;
            PlayerPrefs.SetInt("CurrentChapter", 2);
            questionnaire.SetActive(false);
            daySystem.GetComponent<DaySystem>().StartCoroutine("DayAndNightSystem");
            ChapterOne.SetActive(false);
            ChapterTwo.SetActive(true);
            player.SetActive(true);
        }

        if (info == 3)
        {
            Cursor.visible = false;
            PlayerPrefs.SetInt("CurrentChapter", 3);
            questionnaire.SetActive(false);
            RenderSettings.ambientIntensity = 0.2f;
            ChapterTwo.SetActive(false);
            ChapterThree.SetActive(true);
            player.SetActive(true);
            player.transform.rotation = new Quaternion(0, 180, 0, 0);
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
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 1);

            if (PlayerPrefs.GetString("Version") == "Complex")
            {
                PlayerPrefs.SetString("PlayerType", "Hero");
                gameObject.transform.FindChild("EndChapterOne").gameObject.GetComponent<ChapterOneEnd>().exitChapter = true;
            }
            
        }

        if (info == "Mage")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 6);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 2);

            if (PlayerPrefs.GetString("Version") == "Complex")
            {
                PlayerPrefs.SetString("PlayerType", "Hero");
                gameObject.transform.FindChild("EndChapterOne").gameObject.GetComponent<ChapterOneEnd>().exitChapter = true;
            }

        }

        if (info == "Assassin")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 7);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 3);

            if (PlayerPrefs.GetString("Version") == "Complex")
            {
                PlayerPrefs.SetString("PlayerType", "Hero");
                gameObject.transform.FindChild("EndChapterOne").gameObject.GetComponent<ChapterOneEnd>().exitChapter = true;
            }

        }

        if (info == "GuardianHit")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 13);
        }

        if (info == "WitchHit")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 12);
        }


            if (info == "WitchEnd_Simple")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 8);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 4);
        }

        if (info == "WitchEnd_Complex")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 9);
            player.GetComponent<PlayerClass>().ExpEarned(100);
        }

        if (info == "Gate")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 11);
        }


        //Chapter Two

        if (info == "ChapterTwoIntroPacifist")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 14);
        }

        if (info == "ChapterTwoIntroKiller")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 15);
        }

        if (info == "ChapterTwoIntroHero")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 16);
        }

        if (info == "GuardDialog")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 17);
        }

        if (info == "GuardHit")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 18);
        }

        if (info == "HideQuest")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 19);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 5);
            }

        }

        if (info == "HideHit")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 20);
        }

        if (info == "KillQuest")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 21);

            if (PlayerPrefs.GetString("Version") != "Complex")
            {
                ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 6);
            }

        }

        if (info == "FindQuestComplex")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 34);
        }

        if (info == "KillQuestComplex")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 35);
        }


        if (info == "HideQuest")
        {

        }


            if (info == "HeroChange")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 23);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 7);

        }

        if (info == "KillerChange")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 24);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 8);

        }

        if (info == "PacifistChange")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 25);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 9);

        }

        if (info == "FindCompleted")
        {
            GameObject.Find("Peasent - Find Quest").GetComponent<Animator>().SetTrigger("Happy");
            player.GetComponent<PlayerClass>().ExpEarned(200);
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 26);
        }

        if (info == "KillCompleted")
        {
            player.GetComponent<PlayerClass>().ExpEarned(200);
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 27);
        }



        //Chapter Three

        if (info == "ChapterThreeIntroPacifist")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 28);
            unlockPlayerType = true;
        }

        if (info == "ChapterThreeIntroKiller")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 29);
            unlockPlayerType = true;
        }

        if (info == "ChapterThreeIntroHero")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 30);
            unlockPlayerType = true;
        }


        if (info == "EndGamePacifist")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 31);
            Invoke("GameEnd", 22f);
        }

        if (info == "EndGameKiller")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 32);
            Invoke("GameEnd", 22f);
        }

        if (info == "EndGameHero")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 33);
            Invoke("GameEnd", 22f);
        }


    }

    public void NarrativeFeedback(int choice)
    {


        if (currentNarrative == "WitchIntro_Simple")
        {
            if (choice == 1)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
                Debug.Log(PlayerPrefs.GetInt("Story"));
            }

            if (choice == 2)
            {
               
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
            if(choice == 0)
            {
                player.GetComponent<PlayerClass>().ExpEarned(100);
                PlayerPrefs.SetString("PlayerType", "Hero");
            }

            if (choice == 1)
            {
                player.GetComponent<PlayerClass>().ExpEarned(100);
                PlayerPrefs.SetString("PlayerType", "Hero");
            }

            if (choice == 2)
            {
                PlayerPrefs.SetString("PlayerType", "Pacifist");
                PlayerPrefs.SetString("PlayerClass", "Nothing");
                player.GetComponent<PlayerClass>().PickClass();
            }

            if (choice == 3)
            {
                PlayerPrefs.SetString("PlayerType", "Killer");
                GameObject.Find("Witch_Simple").GetComponent<EnemyRanged>().enabled = true;
            }

            gameObject.transform.FindChild("EndChapterOne").gameObject.GetComponent<ChapterOneEnd>().exitChapter = true;
        }

        if (currentNarrative == "HeroChange" || currentNarrative == "KillerChange" || currentNarrative == "PacifistChange")
        {
            if (choice == 1)
            {
                PlayerPrefs.SetString("PlayerClass", "Warrior");
            }

            if (choice == 2)
            {
                PlayerPrefs.SetString("PlayerClass", "Mage");
            }

            if (choice == 3)
            {
                PlayerPrefs.SetString("PlayerClass", "Assassin");
            }

            player.GetComponent<PlayerClass>().PickClass();
        }

        if (currentNarrative == "HideQuest")
        {
            if(choice == 1)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
            }

            if (choice == 2)
            {

            }

            if (choice == 3)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") - 1);
                GameObject.Find("Peasent - Find Quest").GetComponent<EnemyMelee>().enabled = true;
            }

        }

        if (currentNarrative == "KillQuest")
        {
            if (choice == 1)
            {
                PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") + 1);
            }

            if (choice == 2)
            {

            }

            if (choice == 3)
            {
                GameObject.Find("Peasent - Find Quest").GetComponent<NPC>().Girl();
            }
        }

    }
   
}
