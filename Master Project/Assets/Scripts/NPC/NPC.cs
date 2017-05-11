using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public bool repeatDialog;

    GameObject UI;

    NarrativeSystem narrative;
    public string dialog;
    public string hitDialog;

    Ray chargeRay;
    RaycastHit chargeHit;

    GameObject title;
    public bool ableSpeak;

    Animator aniObject;

    int hitByPlayer;

    private void Awake()
    {
        UI = GameObject.Find("UI");
        narrative = GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>();

        if(gameObject.GetComponent<Animator>() != null)
        {
            aniObject = gameObject.GetComponent<Animator>();
        }
        

    }

    // Use this for initialization
    void Start () {
        ableSpeak = false;
        hitByPlayer = 0;

        if (PlayerPrefs.GetString("Version") == "Complex")
        {

            if (gameObject.name == "Peasent - Kill Quest")
            {
                dialog = "KillQuestComplex";
            }

            if (gameObject.name == "Peasent - Find Quest")
            {
                dialog = "FindQuestComplex";
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
        if(ableSpeak)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                chargeRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(chargeRay, out chargeHit))
                {
                    if (chargeHit.transform.tag == "NPC")
                    {
                        if (gameObject.GetComponent<Animator>() != null)
                        {
                            aniObject.SetTrigger("Talk");
                        }
                        narrative.Narrative(dialog);
   
                        if(!repeatDialog)
                        {
                            ableSpeak = false;
                            UI.transform.FindChild("Interact").gameObject.SetActive(false);
                            gameObject.transform.FindChild("SpeakArea").gameObject.SetActive(false);
                        }
                       
                    }
                }


               
            }
        } 

	}

    public void npcHit()
    {
        ++hitByPlayer;

        if(hitByPlayer == 1)
        {
            narrative.Narrative(hitDialog);
        }

        if (hitByPlayer == 2)
        {
            if (gameObject.name == "Witch_Simple" || gameObject.name == "Witch_Complex")
            {
                gameObject.GetComponent<EnemyRanged>().enabled = true;
                PlayerPrefs.SetString("PlayerType", "Killer");
                GameObject.Find("NarrativeSystem").transform.FindChild("EndChapterOne").gameObject.GetComponent<ChapterOneEnd>().exitChapter = true;

            }

            if (gameObject.name == "Guard")
            {
                gameObject.GetComponent<EnemyMelee>().enabled = true;
            }

            if (gameObject.name == "Peasent - Kill Quest")
            {
                gameObject.GetComponent<EnemyMelee>().enabled = true;
            }

            if (gameObject.name == "Peasent - Find Quest")
            {
                Girl();
            }

            if(GameObject.Find("Interact") != null)
            {
                GameObject.Find("Interact").SetActive(false);
            }
            
            gameObject.transform.FindChild("SpeakArea").gameObject.SetActive(false);
            gameObject.GetComponent<NPC>().enabled = false;
        }
    }

    public void Girl()
    {
        PlayerPrefs.SetInt("Story", PlayerPrefs.GetInt("Story") - 1);
        PlayerPrefs.SetInt("KillerPoints", PlayerPrefs.GetInt("KillerPoints") + 1);
        PlayerPrefs.SetInt("NPCsKilled", 1);
        PlayerPrefs.SetInt("Destruction", PlayerPrefs.GetInt("Destruction") + 1);

        GameObject.Find("Player").GetComponent<PlayerClass>().ExpEarned(200);

        aniObject.SetTrigger("Death");
        Destroy(gameObject, 7);
    }

}
